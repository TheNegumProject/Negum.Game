using System.Collections.Generic;
using System.Linq;
using Negum.Core.Managers.Entries;
using Negum.Game.Common.Entities;

namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Represents Player's key-related definition and logic.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class PlayerKeys
    {
        /// <summary>
        /// Input Manager connected with the current object.
        /// </summary>
        private IInputManager InputManager { get; }

        /// <summary>
        /// Represents a cache which stores all information about previously pressed keys.
        /// </summary>
        private PlayerKeysCache Cache { get; }

        /// <summary>
        /// Represents key mapping and available keys.
        /// </summary>
        public PlayerKeyBinding Keys { get; }

        public PlayerKeys(IInputManager inputManager, IKeysEntry keys)
        {
            this.InputManager = inputManager;
            this.Keys = new PlayerKeyBinding(keys);
            this.Cache = new PlayerKeysCache();
        }

        public virtual void OnKeyPressed(IEnumerable<int> keyCodes)
        {
            // TODO: Add support / idea for how to handle when key is pressed, when released (tilda-symbol in command)

            // Pressed keys which are recognized for the current Player
            var knownPressedKeys = keyCodes
                .Select(code => this.Keys.AllKeys.FirstOrDefault(key => key.CurrentKeyCode == code))
                .Where(key => key != null)
                .ToList();

            this.Cache.RegisterPressed(knownPressedKeys);
        }

        public virtual void Tick(Player player)
        {
            if (this.InputManager.Client.Screen.IsGuiOpened)
            {
                this.HandleForGui();
            }
            else if (player != null)
            {
                this.HandleForMatch(player);
            }
        }

        /// <summary>
        /// Updates GUI state, markers, highlighted options, etc. OR closes the GUI.
        /// </summary>
        protected virtual void HandleForGui()
        {
            // TODO: Update GUI state, markers, highlighted options, etc. OR close GUI
        }

        /// <summary>
        /// Processes keys for the current Match.
        /// </summary>
        /// <param name="player"></param>
        protected virtual void HandleForMatch(Player player)
        {
            // TODO: Update Player based on pressed keys

            this.Cache.Tick();

            // TODO: Perform combo and clear Cached keys
        }
    }
}