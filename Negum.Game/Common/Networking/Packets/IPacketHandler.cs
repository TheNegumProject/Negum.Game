using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Responsible for handling specific Packet type. <br />
/// <br />
/// NOTE: <br />
/// Developers should treat PacketHandlers as classes without any constructors. <br />
/// All the data should be taken from <see cref="NegumGameContainer.Resolve{TInterface}"/>. <br />
/// Any PacketHandler should also be tagged with an <see cref="PacketHandlerAttribute"/>.
/// </summary>
public interface IPacketHandler<in TPacket> 
    where TPacket : IPacket
{
    /// <summary>
    /// Handles given packet.
    /// </summary>
    /// <param name="packet">Packet to handle.</param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task HandleAsync(TPacket packet, CancellationToken token = default);
}