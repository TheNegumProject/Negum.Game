using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Used for handling Packets.
/// </summary>
public interface IPacketProcessor
{
    /// <summary>
    /// Processes packet for all handlers on specified side.
    /// </summary>
    /// <param name="packet"></param>
    /// <param name="side"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task ProcessPacketAsync(IPacket packet, Side side, CancellationToken token = default);
}

public class PacketProcessor : IPacketProcessor
{
    public virtual Task ProcessPacketAsync(IPacket packet, Side side, CancellationToken token = default)
    {
        const string handleAsyncCallbackName = nameof(IPacketHandler<IPacket>.HandleAsync);
        
        var handlers = NegumGameContainer.Resolve<IPacketHandlerRegistry>().GetPacketHandlers(packet, side);

        var tasks = handlers
            .Select(handler =>
            {
                var handleAsyncCallback = handler.GetType().GetMethod(handleAsyncCallbackName);
                var result = handleAsyncCallback?.Invoke(handler, new object?[] { packet, token });

                if (result is null)
                {
                    return Task.CompletedTask;
                }

                return (Task)result;
            })
            .ToArray();

        Task.WaitAll(tasks);
        
        return Task.CompletedTask;
    }
}