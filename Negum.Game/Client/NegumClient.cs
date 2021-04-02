using System;
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

        /// <summary>
        /// FPS.
        /// </summary>
        private int RefreshRate { get; }

        // TODO: Add ClientHooks with multiple events like: Draw, PlayAudio, PressKey, etc.
        public NegumClient(Thread callerThread, ISideConfiguration config /*, IClientHooks clientHooks */)
        {
            this.PacketHandler = new ClientPacketHandler(this);

            this.CallerThread = callerThread;
            this.LocalServerContext = config.ConnectionContext;
            this.RefreshRate = config.FrameRate;
        }

        public async Task StartAsync()
        {
            var frameRate = 1000 / this.RefreshRate;
            var lastTime = DateTime.Now;
            
            while (this.CallerThread.IsAlive)
            {
                var deltaTime = DateTime.Now - lastTime;
                lastTime += deltaTime;
                var deltaTimeElapsed = deltaTime.TotalMilliseconds / 1000;
                
                await this.TickAsync(deltaTimeElapsed);
                
                await Task.Delay(frameRate);
            }

            await this.StopAsync();
        }

        public async Task StopAsync()
        {
            // TODO: Stop any pending operations
            // TODO: Disconnect from any connected servers
        }

        /// <summary>
        /// Performs single tick.
        /// </summary>
        protected virtual async Task TickAsync(double deltaTime)
        {
            /*
             * ---=== Client Main Loop ===---
             *
             * - Get Key Input (call Hook)
             * 
             * - If in Menu (GUI) (When the game starts you are always in menu / intro screen)
             * --- [GUI] Update Menu (GUI)
             * --- [GUI] Render Menu (GUI)
             *
             * - If tries to connect / load game
             * --- Create appropriate connection and create new Network Manager
             *
             * - If in game:
             * --- Send packet to server to synchronise game / match state (Players, Particles, Stage, positions, etc.)
             * --- Spawn Players (On Round Start) (respawn bots, spawn bots, etc.)
             * --- Update Player data
             * --- Adjust Camera (call Hook ???)
             * --- Render Stage (call Hook)
             * --- Render Players (call Hook)
             * --- When game ends AND player don't want rematch, Disconnect Network Manager and NULL it
             *
             * - If Pause button was pressed:
             * --- [GUI] Update Pause Menu
             * --- [GUI] Render Pause Menu
             */
        }
    }
}