using System.Collections.Generic;
using Negum.Core.Managers.Entries;
using Negum.Game.Client.Match;

namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Contains information about KeyBindings for a Player.
    /// On the initial start keys are mapped from configuration.
    /// During the game it is possible to change mapping for specific keys. 
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class PlayerKeyBinding
    {
        public KeyBinding Jump { get; }
        public KeyBinding Crouch { get; }
        public KeyBinding Left { get; protected set; } // TODO: Update based on player1 position in relative to player2 position
        public KeyBinding Right { get; protected set; } // TODO: Update based on player1 position in relative to player2 position
        public KeyBinding A { get; }
        public KeyBinding B { get; }
        public KeyBinding C { get; }
        public KeyBinding X { get; }
        public KeyBinding Y { get; }
        public KeyBinding Z { get; }
        public KeyBinding Start { get; }

        // TODO: Add instant kill button (F1) - disable it in multiplayer

        /// <summary>
        /// Collection of all known keys.
        /// </summary>
        public IEnumerable<KeyBinding> AllKeys => new[]
        {
            Jump, Crouch, Left, Right,
            A, B, C,
            X, Y, Z,
            Start
        };

        public PlayerKeyBinding(IKeysEntry keys)
        {
            this.Jump = new KeyBinding(keys.Jump, Direction.Up.ToString());
            this.Crouch = new KeyBinding(keys.Crouch, Direction.Down.ToString());
            this.Left = new KeyBinding(keys.Left, Direction.Backward.ToString());
            this.Right = new KeyBinding(keys.Right, Direction.Forward.ToString());
            this.A = new KeyBinding(keys.A, "a");
            this.B = new KeyBinding(keys.B, "b");
            this.C = new KeyBinding(keys.C, "c");
            this.X = new KeyBinding(keys.X, "x");
            this.Y = new KeyBinding(keys.Y, "y");
            this.Z = new KeyBinding(keys.Z, "z");
            this.Start = new KeyBinding(keys.Start, "START");
        }
    }
}