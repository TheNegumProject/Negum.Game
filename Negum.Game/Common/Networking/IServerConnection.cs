using System.IO;
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
        await SendPacketToServerAsync(packet);
        await ProcessServerResponseAsync();
    }

    private async Task SendPacketToServerAsync(IPacket packet)
    {
        var packetData = NegumGameContainer.Resolve<IPacketSerializer>().Serialize(packet);
        var serverConfig = NegumGameContainer.Resolve<IServerConfiguration>();

        await Client.ConnectAsync(serverConfig.HostName, serverConfig.Port);
        await Client.GetStream().WriteAsync(packetData);
    }

    private async Task ProcessServerResponseAsync()
    {
        var stream = Client.GetStream();
        var reader = new BinaryReader(stream);
        var packetDataLength = reader.ReadInt64();
        var packetData = new byte[packetDataLength];

        var bytesRead = await stream.ReadAsync(packetData);

        if (bytesRead == 0)
        {
            return;
        }

        var packet = NegumGameContainer.Resolve<IPacketSerializer>().Deserialize(packetData);

        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(packet, Side.Client);
    }
}