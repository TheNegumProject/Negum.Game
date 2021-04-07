using System.Collections.Generic;

namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Storage used to store information about previous keys presses.
    /// Stored information is used to indicate if combo should be called.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class PlayerKeysCache
    {
        /// <summary>
        /// Collection of keys which were pressed.
        /// Since there might be multiple buttons pressed at the same time, we need to support collection of keys.
        /// </summary>
        protected Queue<IEnumerable<KeyBinding>> PressedKeys { get; } = new();

        /// <summary>
        /// Registers information about pressed keys and store that information for future combo-related logic.
        /// </summary>
        /// <param name="pressedKeys"></param>
        public virtual void RegisterPressed(IEnumerable<KeyBinding> pressedKeys)
        {
            this.PressedKeys.Enqueue(pressedKeys);
        }

        /// <summary>
        /// Ticks current cached pressed keys.
        /// After a configurable period of time clears previously pressed keys.
        /// This was meant to indicate that Player missclicked something while trying to perform a combo.
        /// </summary>
        public virtual void Tick()
        {
            // TODO: Add logic
            // TODO: How to pass / get wanted period of time ???
            // TODO: How to calculate this period ???
            // TODO: When to start calculating the difference ???
        }
    }
}