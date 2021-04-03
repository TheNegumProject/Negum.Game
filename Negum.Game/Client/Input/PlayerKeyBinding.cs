using Negum.Core.Managers.Entries;

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
        public KeyBinding Left { get; }
        public KeyBinding Right { get; }
        public KeyBinding A { get; }
        public KeyBinding B { get; }
        public KeyBinding C { get; }
        public KeyBinding X { get; }
        public KeyBinding Y { get; }
        public KeyBinding Z { get; }
        public KeyBinding Start { get; }
        
        public PlayerKeyBinding(IKeysEntry keys)
        {
            this.Jump = new KeyBinding(keys.Jump);
            this.Crouch = new KeyBinding(keys.Crouch);
            this.Left = new KeyBinding(keys.Left);
            this.Right = new KeyBinding(keys.Right);
            this.A = new KeyBinding(keys.A);
            this.B = new KeyBinding(keys.B);
            this.C = new KeyBinding(keys.C);
            this.X = new KeyBinding(keys.X);
            this.Y = new KeyBinding(keys.Y);
            this.Z = new KeyBinding(keys.Z);
            this.Start = new KeyBinding(keys.Start);
        }

        /// <summary>
        /// Presses a specified key.
        /// </summary>
        /// <param name="keyCode"></param>
        public virtual void OnKeyPressed(int keyCode)
        {
            this.Jump.OnKeyPressed(keyCode);
            this.Crouch.OnKeyPressed(keyCode);
            this.Left.OnKeyPressed(keyCode);
            this.Right.OnKeyPressed(keyCode);
            this.A.OnKeyPressed(keyCode);
            this.B.OnKeyPressed(keyCode);
            this.C.OnKeyPressed(keyCode);
            this.X.OnKeyPressed(keyCode);
            this.Y.OnKeyPressed(keyCode);
            this.Z.OnKeyPressed(keyCode);
            this.Start.OnKeyPressed(keyCode);
        }
    }
}