using System;
using System.Threading;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Game.Client.Input;
using Negum.Game.Client.Network;
using Negum.Game.Common.Configurations;
using Negum.Game.Common.Network;

namespace Negum.Game.Client
{
    /// <summary>
    /// Main Client class used to initialize the engine and main loop.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class NegumClient : INegumClient
    {
        public IPacketHandler PacketHandler { get; }
        public INetworkManager NetworkManager { get; }
        public Thread CallerThread { get; }
        public IConnectionContext LocalServerContext { get; }
        public int RefreshRate { get; }
        public IEngine Engine { get; }
        public IInputManager Input { get; }
        public IClientHooks Hooks { get; }

        // TODO: Add ClientHooks with multiple events like: Draw, PlayAudio, PressKey, etc.
        public NegumClient(ISideConfiguration config)
        {
            this.PacketHandler = this.ResolveModule<IClientPacketHandler>();
            this.Input = this.ResolveModule<IInputManager>();
            this.Hooks = this.ResolveModule<IClientHooks>();

            this.CallerThread = config.CallerThread;
            this.LocalServerContext = config.ConnectionContext;
            this.RefreshRate = config.FrameRate;
            this.Engine = config.Engine;
        }

        public async Task StartAsync()
        {
            this.Input.ProcessKeys();

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
        public virtual async Task TickAsync(double deltaTime)
        {
            /*
             * TODO: ---=== Client Main Loop ===---
             *
             * - Get Key Input (call Hook) (this hook will be called from outside)
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

            // TODO: ---=== Implementation start here ===---

            // this.GuiManager.Tick(); // TODO: Handle Updating and Rendering GUI - GuiManager vs ScreenManager ?
            this.Input.Tick(deltaTime);
            // this.MatchManager.Tick(deltaTime); // TODO: Update current Match
            // this.RenderManager.Tick(deltaTime); // TODO: Render GUI, Stage, Players, Particles, etc.
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TClientModule"></typeparam>
        /// <returns>New module for the current Client.</returns>
        private TClientModule ResolveModule<TClientModule>()
            where TClientModule : IClientModule =>
            (TClientModule) NegumContainer.Resolve<TClientModule>().Use(this);
    }
}