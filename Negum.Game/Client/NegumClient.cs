using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Client.Network;
using Negum.Game.Common.Configurations;
using Negum.Game.Common.Network;

namespace Negum.Game.Client
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class NegumClient : INegumClient
    {
        public IPacketHandler PacketHandler { get; }
        public INetworkManager NetworkManager { get; }

        /// <summary>
        /// Thread on which the current Client was created.
        /// </summary>
        private Thread CallerThread { get; }

        /// <summary>
        /// Context for local server connection.
        /// This should be used every time Client plays game that is not multiplayer-specific.
        /// </summary>
        private IConnectionContext LocalServerContext { get; }

        // TODO: Add ClientHooks with multiple events like: Draw, PlayAudio, PressKey, etc.
        public NegumClient(Thread callerThread, ISideConfiguration config /*, IClientHooks clientHooks */)
        {
            this.PacketHandler = new ClientPacketHandler(this);

            this.CallerThread = callerThread;
            this.LocalServerContext = config.ConnectionContext;
        }

        public async Task StartAsync()
        {
            while (this.CallerThread.IsAlive)
            {
                await this.TickAsync();
            }
        }

        public async Task StopAsync()
        {
        }

        /// <summary>
        /// Performs single tick.
        /// </summary>
        protected virtual async Task TickAsync()
        {
            /*
             * ---=== Client Match Main Loop ===---
             *
             * - If game just starts
             * --- Create appropriate connection and create new Network Manager
             *
             * - If in game:
             * --- Send packet to server to synchronise game / match state (Players, Particles, Stage, positions, etc.)
             * --- Process Key Input (call Hook)
             * --- Spawn Players (On Round Start) (respawn bots, spawn bots, etc.)
             * --- Adjust Camera (call Hook ???)
             * --- Render Stage (call Hook)
             * --- Render Players (call Hook)
             * --- When game ends AND player don't want rematch, Disconnect Network Manager and NULL it
             * 
             * - If in game AND pressed pause button
             * --- [GUI] Update Pause Menu
             * --- [GUI] Render Pause Menu
             *
             * - If not in game:
             * --- [GUI] Update Menu (GUI) (if any open)
             * --- [GUI] Render Menu (GUI)
             */
        }
    }
}