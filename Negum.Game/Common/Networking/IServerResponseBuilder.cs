using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for building response 
/// </summary>
public interface IServerResponseBuilder
{
    /// <summary>
    /// Builds response Packet based on specified input Packet.
    /// </summary>
    /// <param name="packet"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<IPacket> BuildAsync(IPacket packet, CancellationToken token = default);
}

public class ServerResponseBuilder : IServerResponseBuilder
{
    public virtual Task<IPacket> BuildAsync(IPacket packet, CancellationToken token = default)
    {
        // TODO: Build appropriate response Packet - maybe return EmptyPacket by default or GameState (: IPacket) for SyncPacket (?)
        return Task.FromResult((IPacket)new EmptyPacket());
    }
}