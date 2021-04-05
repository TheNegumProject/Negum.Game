namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Describes single key.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class KeyBinding
    {
        /// <summary>
        /// KeyCode read from configuration.
        /// 
        /// NOTE:
        /// This will allow for resetting the key to "default" value.
        /// </summary>
        protected int InitialKeyCode { get; }

        /// <summary>
        /// String-representation of the current key.
        /// </summary>
        protected string Symbol { get; }

        /// <summary>
        /// KeyCode currently being used.
        /// </summary>
        public int CurrentKeyCode { get; protected set; }

        public KeyBinding(int keyCode, string symbol)
        {
            this.InitialKeyCode = keyCode;
            this.Symbol = symbol;

            this.SetKey(keyCode);
        }

        /// <summary>
        /// Sets new key for the current binding.
        /// </summary>
        /// <param name="keyCode"></param>
        public virtual void SetKey(int keyCode)
        {
            this.CurrentKeyCode = keyCode;
        }

        /// <summary>
        /// </summary>
        /// <returns>Key string representation.</returns>
        public override string ToString() => this.Symbol;
    }
}