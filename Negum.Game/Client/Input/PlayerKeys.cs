using System.Collections.Generic;
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
        /// Represents key mapping and available keys.
        /// </summary>
        public PlayerKeyBinding Keys { get; }

        public PlayerKeys(IKeysEntry keys)
        {
            this.Keys = new PlayerKeyBinding(keys);
        }

        public virtual void OnKeyPressed(IEnumerable<int> keyCodes)
        {
            // TODO: Add support / idea for how to handling when key is pressed when release (tilda-symbol in command)
            // TODO: Cache pressed keys
        }

        public virtual void Tick(IInputManager manager, Player player)
        {
            // TODO: If "manager" != null then update GUI / Screen
            // TODO: Else if "player" != null then update player / match, execute combo, etc.
            
            // TODO: Read combinations from some cached previous presses and check if any combo can be executed
            // TODO: If in GUI / Screen update cursor / marker / highlight
        }
    }
}