using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;
using Negum.Game.Common.Tasks;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for listening for incoming messages from clients.
/// </summary>
public interface IServerListener : IRunnableService
{
}

public class ServerListener : IServerListener
{
    private TcpListener? Server { get; set; }
    
    public virtual async Task RunAsync(int port = default, CancellationToken token = default)
    {
        var networkHelper = NegumGameContainer.Resolve<INetworkHelper>();
        port = port > 0 ? port : networkHelper.GetNextFreePort();

        Server = TcpListener.Create(port);
        Server.Start();
        
        NegumGameContainer.Resolve<IServerConfiguration>().ToggleLocalServerRunning();

        while (!token.IsCancellationRequested)
        {
            using var client = await Server.AcceptTcpClientAsync(token);
            await HandleClientAsync(client, token);
        }
    }

    private static async Task HandleClientAsync(TcpClient client, CancellationToken token = default)
    {
        var stream = client.GetStream();
        var networkPacketSerializer = NegumGameContainer.Resolve<INetworkPacketSerializer>();
        
        // Process Client Request

        var requestPacket = await networkPacketSerializer.ReadAsync(stream, token);
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(requestPacket, Side.Server, token);

        // Send Response to Client

        var responsePacket = await NegumGameContainer.Resolve<IServerResponseBuilder>().BuildAsync(requestPacket, token);
        await networkPacketSerializer.WriteAsync(stream, responsePacket, token);
    }
}