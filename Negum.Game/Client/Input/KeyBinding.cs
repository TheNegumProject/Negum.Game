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
        /// KeyCode currently being used.
        /// </summary>
        protected int CurrentKeyCode { get; set; }

        /// <summary>
        /// Indicates a total number of registered clicks which needs to be handled in main loop.
        /// </summary>
        protected int Clicks { get; set; }

        public KeyBinding(int keyCode)
        {
            this.InitialKeyCode = keyCode;

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
        /// Tries to click the button.
        /// </summary>
        /// <param name="keyCode"></param>
        public virtual void OnKeyPressed(int keyCode)
        {
            if (this.CurrentKeyCode == keyCode)
            {
                this.Clicks++;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>True if the key should be handled; otherwise false.</returns>
        public virtual bool HandlePressed()
        {
            if (this.Clicks == 0)
            {
                return false;
            }

            this.Clicks--;
            return true;
        }
    }
}