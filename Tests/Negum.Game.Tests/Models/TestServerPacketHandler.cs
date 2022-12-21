using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Networking;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Tests.Models;

[PacketHandler(Side.Server)]
public class TestServerPacketHandler : IPacketHandler<TestPacket>
{
    public Task HandleAsync(TestPacket packet, CancellationToken token = default)
    {
        return Task.CompletedTask;
    }
}