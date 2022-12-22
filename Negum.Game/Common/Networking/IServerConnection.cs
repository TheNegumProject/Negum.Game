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
    public virtual async Task SendPacketAsync(IPacket packet, CancellationToken token = default)
    {
        var networkPacketSerializer = NegumGameContainer.Resolve<INetworkPacketSerializer>();
        
        // Send to Server
        
        var serverConfig = NegumGameContainer.Resolve<IServerConfiguration>();
        
        // Give local server some time to start
        while (!serverConfig.IsLocalServerRunning && !token.IsCancellationRequested)
        {
            Thread.Sleep(1000);
        }
        
        var client = new TcpClient(serverConfig.HostName, serverConfig.Port);
        
        await networkPacketSerializer.WriteAsync(client.GetStream(), packet, token);
        
        // Process Server Response
        
        var responsePacket = await networkPacketSerializer.ReadAsync(client.GetStream(), token);
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(responsePacket, Side.Client, token);
        
        // Clean connection
        
        client.Close();
    }
}