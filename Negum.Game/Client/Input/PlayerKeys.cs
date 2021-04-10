using System.Collections.Generic;
using System.Linq;
using Negum.Core.Managers.Entries;

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
        /// Collection of keys which were pressed.
        /// Since there might be multiple buttons pressed at the same time, we need to support collection of keys.
        /// Used to check if Player pressed keys equal to any combo.
        /// </summary>
        private Queue<IEnumerable<KeyBinding>> PressedKeys { get; } = new();

        /// <summary>
        /// Collection of yet unprocessed pressed keys.
        /// Used to handle each individual keys.
        /// </summary>
        private Queue<IEnumerable<KeyBinding>> UnprocessedKeys { get; } = new();

        /// <summary>
        /// Input Manager connected with the current object.
        /// </summary>
        private IInputManager InputManager { get; }

        /// <summary>
        /// Represents key mapping and available keys.
        /// </summary>
        public PlayerKeyBinding Keys { get; }

        public PlayerKeys(IInputManager inputManager, IKeysEntry keys)
        {
            this.InputManager = inputManager;
            this.Keys = new PlayerKeyBinding(keys);
        }

        public virtual void OnKeyPressed(IEnumerable<int> keyCodes)
        {
            // TODO: Add support / idea for how to handle when key is pressed, when released (tilda-symbol in command)

            // Pressed keys which are recognized for the current Player
            var knownPressedKeys = keyCodes
                .Select(code => this.Keys.AllKeys.FirstOrDefault(key => key.CurrentKeyCode == code))
                .Where(key => key != null)
                .ToList();

            this.PressedKeys.Enqueue(knownPressedKeys);
            this.UnprocessedKeys.Enqueue(knownPressedKeys);
        }
    }
}