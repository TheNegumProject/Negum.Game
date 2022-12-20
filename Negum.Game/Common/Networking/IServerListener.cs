using System.Net.Sockets;
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
    /// <returns></returns>
    Task StartAsync(int port = default);

    /// <summary>
    /// Stops the listener.
    /// </summary>
    /// <returns></returns>
    Task StopAsync();
}

public class ServerListener : IServerListener
{
    private bool Running { get; set; }
    private TcpListener? Server { get; set; }
    
    public async Task StartAsync(int port = default)
    {
        if (Running)
        {
            return;
        }
        
        Running = true;

        var networkHelper = NegumGameContainer.Resolve<INetworkHelper>();
        // var address = networkHelper.GetLocalAddress();
        // var localAddr = IPAddress.Parse(address);
        port = port > 0 ? port : networkHelper.GetNextFreePort();

        Server = TcpListener.Create(port); // new TcpListener(localAddr, port);
        Server.Start();

        while (Running)
        {
            using var client = await Server.AcceptTcpClientAsync();
            await Task.Run(async () => await HandleClientAsync(client));
        }
    }

    public Task StopAsync()
    {
        Running = false;
        return Task.CompletedTask;
    }
    
    private static async Task HandleClientAsync(TcpClient client)
    {
        var stream = client.GetStream();
        var networkPacketSerializer = NegumGameContainer.Resolve<INetworkPacketSerializer>();
        
        // Process Client Request

        var requestPacket = await networkPacketSerializer.ReadAsync(stream);
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(requestPacket, Side.Server);

        // Send Response to Client

        var responsePacket = new EmptyPacket(); // TODO: Add appropriate response Packet
        await networkPacketSerializer.WriteAsync(stream, responsePacket);
    }
}