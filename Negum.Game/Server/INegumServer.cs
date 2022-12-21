using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
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
    Task StartAsync(int port = default, CancellationToken token = default);
    
    /// <summary>
    /// Stops server (listening loop).
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task StopAsync(CancellationToken token = default);
}

public class NegumServer : INegumServer
{
    public virtual async Task StartAsync(int port = default, CancellationToken token = default)
    {
        await NegumGameContainer
            .Resolve<INetworkManager>()
            .SendPacketAsync(new InitializeServerPacket(), token);
        
        await NegumGameContainer.Resolve<IServerListener>().StartAsync(port, token);
    }

    public virtual async Task StopAsync(CancellationToken token = default) => 
        await NegumGameContainer.Resolve<IServerListener>().StopAsync(token);
}