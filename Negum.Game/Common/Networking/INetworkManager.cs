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
    /// <returns></returns>
    Task SendPacketAsync<TPacket>(TPacket packet)
        where TPacket : IPacket;
}

public class NetworkManager : INetworkManager
{
    /// <summary>
    /// Handles Packet for Server and Client.
    /// </summary>
    /// <param name="packet"></param>
    /// <typeparam name="TPacket"></typeparam>
    /// <returns></returns>
    public async Task SendPacketAsync<TPacket>(TPacket packet) 
        where TPacket : IPacket
    {
        // Process Packet - Server
        await NegumGameContainer.Resolve<IServerConnection>().SendPacketAsync(packet);
        
        // Process Packet - Client
        // await NegumGameContainer.Resolve<IPacketProcessor>().ProcessPacketAsync(packet, Side.Client); // TODO: Implement
    }
}