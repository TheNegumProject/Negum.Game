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
    public ServerConnection()
    {
        Client = new TcpClient();
    }
    
    private TcpClient Client { get; }
    
    public async Task SendPacketAsync(IPacket packet)
    {
        var networkPacketSerializer = NegumGameContainer.Resolve<INetworkPacketSerializer>();
        
        // Send to Server
        
        var serverConfig = NegumGameContainer.Resolve<IServerConfiguration>();
        await Client.ConnectAsync(serverConfig.HostName, serverConfig.Port);
        await networkPacketSerializer.WriteAsync(Client.GetStream(), packet);
        
        // Process Server Response
        
        var responsePacket = await networkPacketSerializer.ReadAsync(Client.GetStream());
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(responsePacket, Side.Client);
    }
}