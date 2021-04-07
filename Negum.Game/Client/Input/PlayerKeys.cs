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
        /// Represents a cache which stores all information about previously pressed keys.
        /// </summary>
        private PlayerKeysCache Cache { get; }
        
        /// <summary>
        /// Represents key mapping and available keys.
        /// </summary>
        public PlayerKeyBinding Keys { get; }

        public PlayerKeys(IKeysEntry keys)
        {
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

        public virtual void Tick(IInputManager manager, Player player)
        {
            // TODO: If "manager" != null then update GUI / Screen
            // TODO: Else if "player" != null then update player / match, execute combo, etc.
            
            // TODO: Read combinations from some cached previous presses and check if any combo can be executed
            // TODO: If in GUI / Screen update cursor / marker / highlight

            this.Cache.Tick();
        }
    }
}