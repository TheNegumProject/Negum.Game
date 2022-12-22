using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Client.Networking.Packets;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
using Negum.Game.Common.States.Packets;
using Negum.Game.Common.Tasks;
using Negum.Game.Server;

namespace Negum.Game.Client;

/// <summary>
/// Represents main game Client.
/// </summary>
public interface INegumClient : IRunnableService
{
}

/// <summary>
/// Avoid initializing this class. <br />
/// For starting the Client please see: <see cref="NegumRunner"/>
/// </summary>
public class NegumClient : INegumClient
{
    public async Task RunAsync(int port = default, CancellationToken token = default)
    {
        // Setup configuration for local server by default
        NegumGameContainer.Resolve<IServerConfiguration>().ConnectToLocalServer();

        // Initialize local server thread
        var localServerThread = new Thread(() =>
        {
            NegumGameContainer.Resolve<INegumServer>().RunAsync(port, token).Wait(token);
        });

        localServerThread.Start();
        
        // Send initialization Packets
        var networkManager = NegumGameContainer.Resolve<INetworkManager>();
        
        await networkManager.SendPacketAsync(new InitializeClientPacket(), token);
        await networkManager.SendPacketAsync(new SyncStatePacket(), token);
    }
}