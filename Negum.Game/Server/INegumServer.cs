using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
using Negum.Game.Common.Networking.Packets;
using Negum.Game.Server.Networking.Packets;

namespace Negum.Game.Server;

/// <summary>
/// Provides convenient wrapper for server listening loop. <br />
/// <br />
///
/// NOTE: <br />
/// For custom server, feel free to implement this interface yourself. <br />
/// Keep in mind to register your new implementation in <see cref="NegumGameContainer"/>.
/// </summary>
public interface INegumServer
{
    /// <summary>
    /// Starts server (listening loop).
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task RunAsync(int port = default, CancellationToken token = default);
}

public class NegumServer : INegumServer
{
    public virtual async Task RunAsync(int port = default, CancellationToken token = default)
    {
        // Special case when IPacketProcessor is used - we have not yet active server
        await NegumGameContainer
            .Resolve<IPacketProcessor>()
            .ProcessPacketAsync(new InitializeServerPacket(), Side.Client, token);
        
        await NegumGameContainer.Resolve<IServerListener>().RunAsync(port, token);
    }
}