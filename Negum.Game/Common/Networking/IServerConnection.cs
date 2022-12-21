using System.Net.Sockets;
using System.Threading;
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
    /// <param name="token"></param>
    /// <returns></returns>
    Task SendPacketAsync(IPacket packet, CancellationToken token = default);
}

public class ServerConnection : IServerConnection
{
    public ServerConnection()
    {
        Client = new TcpClient();
    }
    
    private TcpClient Client { get; }
    
    public async Task SendPacketAsync(IPacket packet, CancellationToken token = default)
    {
        var networkPacketSerializer = NegumGameContainer.Resolve<INetworkPacketSerializer>();
        
        // Send to Server
        
        var serverConfig = NegumGameContainer.Resolve<IServerConfiguration>();
        await Client.ConnectAsync(serverConfig.HostName, serverConfig.Port, token);
        await networkPacketSerializer.WriteAsync(Client.GetStream(), packet, token);
        
        // Process Server Response
        
        var responsePacket = await networkPacketSerializer.ReadAsync(Client.GetStream(), token);
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(responsePacket, Side.Client, token);
    }
}