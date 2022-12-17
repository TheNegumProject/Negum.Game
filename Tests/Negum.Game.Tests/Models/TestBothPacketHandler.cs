using System.Threading.Tasks;
using Negum.Game.Common.Networking;

namespace Negum.Game.Tests.Models;

[PacketHandler(Side.Client)]
[PacketHandler(Side.Server)]
public class TestBothPacketHandler : IPacketHandler<TestPacket>
{
    public Task HandleAsync(TestPacket packet)
    {
        return Task.CompletedTask;
    }
}