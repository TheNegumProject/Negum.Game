namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Represents a Manager which is responsible for handling input-related operations.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class InputManager
    {
        protected INegumClient Client { get; }
        
        public PlayerKeyBinding Player1Keys { get; protected set; }
        public PlayerKeyBinding Player2Keys { get; protected set; }

        public InputManager(INegumClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Reads all keys from Client's engine object and processes it.
        /// </summary>
        public virtual void ProcessKeys()
        {
            var config = this.Client.Engine.Data.ConfigManager;

            this.Player1Keys = new PlayerKeyBinding(config.P1Keys.Keys);
            this.Player2Keys = new PlayerKeyBinding(config.P2Keys.Keys);

            // TODO: Add support for Joystick variables from Engine - config.P1Joystick.Keys, etc. - Do we need it ???
            // TODO: Add support for InputDirMode
            // TODO: Add support for AnyKeyUnpauses
        }

        /// <summary>
        /// Presses a specified key.
        /// </summary>
        /// <param name="keyCode"></param>
        public virtual void OnKeyPressed(int keyCode)
        {
            this.Player1Keys.OnKeyPressed(keyCode);
            this.Player2Keys.OnKeyPressed(keyCode);
        }
    }
}