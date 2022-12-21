using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Client.Networking.Packets;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
using Negum.Game.Server;

namespace Negum.Game.Client;

/// <summary>
/// Represents main game Client.
/// </summary>
public interface INegumClient
{
    /// <summary>
    /// Starts Client with local Server.
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task StartAsync(int port = default, CancellationToken token = default);
    
    /// <summary>
    /// Stops Client and local Server.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task StopAsync(CancellationToken token = default);
}

/// <summary>
/// Avoid initializing this class. <br />
/// For starting the Client please see: <see cref="NegumClientRunner"/>
/// </summary>
public class NegumClient : INegumClient
{
    public async Task StartAsync(int port = default, CancellationToken token = default)
    {
        // Setup configuration for local server by default
        NegumGameContainer.Resolve<IServerConfiguration>().ConnectToLocalServer();

        // Initialize local server thread
        var localServerThread = new Thread(() =>
        {
            NegumGameContainer.Resolve<INegumServer>().StartAsync(port, token).Wait(token);
        });

        localServerThread.Start();
        
        // Send initialization Packet
        await NegumGameContainer
            .Resolve<INetworkManager>()
            .SendPacketAsync(new InitializeClientPacket(), token);
    }

    public async Task StopAsync(CancellationToken token = default) => 
        await NegumGameContainer.Resolve<INegumServer>().StopAsync(token);
}