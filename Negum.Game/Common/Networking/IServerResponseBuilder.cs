using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

public interface IServerResponseBuilder
{
    Task<IPacket> BuildAsync(CancellationToken token = default);
}

public class ServerResponseBuilder : IServerResponseBuilder
{
    public Task<IPacket> BuildAsync(CancellationToken token = default)
    {
        // TODO: Build appropriate response Packet
        return Task.FromResult((IPacket)new EmptyPacket());
    }
}