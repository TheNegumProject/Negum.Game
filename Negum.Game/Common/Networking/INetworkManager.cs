using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for network-related features.
/// </summary>
public interface INetworkManager
{
    /// <summary>
    /// </summary>
    /// <param name="packet">Packet to be send.</param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task SendPacketAsync<TPacket>(TPacket packet, CancellationToken token = default)
        where TPacket : IPacket;
}

public class NetworkManager : INetworkManager
{
    public virtual async Task SendPacketAsync<TPacket>(TPacket packet, CancellationToken token = default) 
        where TPacket : IPacket
    {
        // Process Packet - Server
        await NegumGameContainer.Resolve<IServerConnection>().SendPacketAsync(packet, token);
        
        // Process Packet - Client
        await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(packet, Side.Client, token);
    }
}