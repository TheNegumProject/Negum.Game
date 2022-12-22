using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
using Negum.Game.Common.Networking.Packets;
using Negum.Game.Common.States;

namespace Negum.Game.Client.Networking.Handlers;

[PacketHandler(Side.Client)]
public class GameStateSyncPacketHandler : IPacketHandler<GameState>
{
    public Task HandleAsync(GameState packet, CancellationToken token = default)
    {
        NegumGameContainer.Resolve<IGameStateProvider>().UpdateGameState(packet);
        
        return Task.CompletedTask;
    }
}