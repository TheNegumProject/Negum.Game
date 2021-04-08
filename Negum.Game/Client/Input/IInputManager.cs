using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negum.Game.Client.Input
{
    /// <summary>
    /// Represents a Manager which is responsible for handling input-related operations.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IInputManager : IClientModule
    {
        /// <summary>
        /// Reads all keys from Client's engine object and processes it.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Presses a specified key.
        /// </summary>
        /// <param name="keyCodes"></param>
        void OnKeyPressed(IEnumerable<int> keyCodes);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class InputManager : ClientModule, IInputManager
    {
        public PlayerKeys Player1Keys { get; protected set; }
        public PlayerKeys Player2Keys { get; protected set; }

        public void Initialize()
        {
            var config = this.Client.Engine.Data.ConfigManager;

            this.Player1Keys = new PlayerKeys(this, config.P1Keys.Keys);
            this.Player2Keys = new PlayerKeys(this, config.P2Keys.Keys);

            // TODO: Add support for Joystick variables from Engine - config.P1Joystick.Keys, etc. - Do we need it ???
            // TODO: Add support for InputDirMode
            // TODO: Add support for AnyKeyUnpauses
        }

        public override void Tick(double deltaTime)
        {
            // We want Players to behave in async order
            var tasks = new[]
            {
                Task.Run(() => this.Player1Keys.Tick(this.Client.Match.GetPlayer(0))),
                Task.Run(() => this.Player2Keys.Tick(this.Client.Match.GetPlayer(1)))
            };

            Task.WaitAll(tasks);
        }

        public virtual void OnKeyPressed(IEnumerable<int> keyCodes)
        {
            this.Player1Keys.OnKeyPressed(keyCodes);
            this.Player2Keys.OnKeyPressed(keyCodes);
        }
    }
}