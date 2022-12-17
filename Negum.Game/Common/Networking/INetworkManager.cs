using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Game.Common.Containers;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for network-related features.
/// </summary>
public interface INetworkManager // TODO: Design how to handle Packet sending between Client and Server
{
    /// <summary>
    /// Calls handlers responsible for handling specified Packet.
    /// All handlers which are registered for specified Packet will be called.
    ///
    /// NOTE:
    /// Handlers might be called in random order!
    /// </summary>
    /// <param name="packet">Packet to be send.</param>
    /// <returns></returns>
    Task SendPacketAsync<TPacket>(TPacket packet)
        where TPacket : IPacket;
}

// public class NetworkManager : INetworkManager
// {
//     /// <summary>
//     /// TODO: Send packet to currently connected server. Either: NegumDedicatedServer (: NegumServer) or NegumServer
//     /// </summary>
//     /// <param name="packet"></param>
//     /// <typeparam name="TPacket"></typeparam>
//     /// <returns></returns>
//     public async Task SendPacketAsync<TPacket>(TPacket packet) where TPacket : IPacket
//     {
//         // var packetHandlerRegistry = NegumGameContainer.Resolve<IPacketHandlerRegistry>();
//         // var packetHandlers = packetHandlerRegistry.GetPacketHandlers<TPacket>(Side.Server);
//         //
//         // foreach (var packetHandler in packetHandlers)
//         // {
//         // }
//         
//         // 1. Wrap Packet - add assembly type + packet Type FullName
//         // 2. Get current connection Stream and write wrapped packet (send to server - dedicated server by default)
//         // 3. Wait for response.... (write response logic INegumSide, INegumClient, INegumServer, INegumDedicatedServer, INegumServerConfiguration)
//         // 4. Read wrapped packet from Stream
//         // 5. Get PacketHandlers - Side.Client
//         // 6. Process response for client PacketHandlers
//     }
// }