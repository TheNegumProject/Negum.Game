using System.Net.Sockets;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for connection with server.
/// </summary>
public interface IServerConnection
{
    /// <summary>
    /// Sends specified Packet to server.
    /// </summary>
    /// <param name="packet">Packet to send.</param>
    /// <returns></returns>
    Task SendPacketAsync(IPacket packet);
}

public class ServerConnection : IServerConnection
{
    private TcpClient Client { get; }
    private IPacketSerializer PacketSerializer { get; }
    private IServerConfiguration ServerConfiguration { get; }

    public ServerConnection()
    {
        Client = new TcpClient();
        
        PacketSerializer = NegumGameContainer.Resolve<IPacketSerializer>();
        ServerConfiguration = NegumGameContainer.Resolve<IServerConfiguration>();
    }
    
    public async Task SendPacketAsync(IPacket packet)
    {
        var packetData = PacketSerializer.Serialize(packet);
        
        await Client.ConnectAsync(ServerConfiguration.HostName, ServerConfiguration.Port);
        
        var clientStream = Client.GetStream();
        
        await clientStream.WriteAsync(packetData);
    }
}