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
    public async Task SendPacketAsync(IPacket packet)
    {
        var packetData = NegumGameContainer.Resolve<IPacketSerializer>().Serialize(packet);
        var serverConfig = NegumGameContainer.Resolve<IServerConfiguration>();
        var client = new TcpClient(serverConfig.HostName, serverConfig.Port);
        var clientStream = client.GetStream();
        
        await clientStream.WriteAsync(packetData);
    }
}