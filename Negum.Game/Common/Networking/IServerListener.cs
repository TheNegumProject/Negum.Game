using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for listening for incoming messages from clients.
/// </summary>
public interface IServerListener
{
    /// <summary>
    /// Starts listening for incoming requests.
    /// </summary>
    /// <param name="port">Port which should be used by local server; leave empty for autodetect.</param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task StartAsync(int port = default, CancellationToken token = default);

    /// <summary>
    /// Stops the listener.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task StopAsync(CancellationToken token = default);
}

public class ServerListener : IServerListener
{
    private bool Running { get; set; }
    private TcpListener? Server { get; set; }
    
    public async Task StartAsync(int port = default, CancellationToken token = default)
    {
        if (Running)
        {
            return;
        }
        
        Running = true;

        var networkHelper = NegumGameContainer.Resolve<INetworkHelper>();
        port = port > 0 ? port : networkHelper.GetNextFreePort();

        Server = TcpListener.Create(port);
        Server.Start();

        while (Running)
        {
            using var client = await Server.AcceptTcpClientAsync(token);
            await Task.Run(async () => await HandleClientAsync(client, token), token);
        }
    }

    public Task StopAsync(CancellationToken token = default)
    {
        Running = false;
        return Task.CompletedTask;
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