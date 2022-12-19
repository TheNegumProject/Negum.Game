using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Exceptions;
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
    /// <returns></returns>
    Task ProcessPacketAsync(IPacket packet, Side side);
}

public class PacketProcessor : IPacketProcessor
{
    public Task ProcessPacketAsync(IPacket packet, Side side)
    {
        var handlers = NegumGameContainer.Resolve<IPacketHandlerRegistry>().GetPacketHandlers(packet, side);
        var handleAsyncCallback = typeof(IPacketHandler<>).GetMethod(nameof(IPacketHandler<IPacket>.HandleAsync));

        if (handleAsyncCallback is null)
        {
            throw new NegumException($"Cannot find HandleAsync method.");
        }

        var tasks = handlers
            .Select(handler =>
            {
                var result = handleAsyncCallback.Invoke(handler, new object?[] { packet });

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