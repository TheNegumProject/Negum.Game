using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;
using Negum.Game.Common.States;
using Negum.Game.Common.States.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for building Server response. 
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
        IPacket responsePacket = new EmptyPacket();
        
        if (packet is ISyncStatePacket)
        {
            responsePacket = NegumGameContainer.Resolve<IGameStateProvider>().GetGameState();
        }

        return Task.FromResult(responsePacket);
    }
}