using Negum.Game.Client.Input;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IScreen
    {
        /// <summary>
        /// Client for which the current screen is being rendered.
        /// </summary>
        INegumClient Client { get; }

        /// <summary>
        /// Setups given binding how each button should behave when the current screen is displayed.
        /// </summary>
        /// <param name="binding"></param>
        void Setup(PlayerKeyBinding binding);

        /// <summary>
        /// Ticks current screen's logic.
        /// </summary>
        /// <param name="deltaTime"></param>
        void Tick(double deltaTime);

        /// <summary>
        /// Renders current screen.
        /// </summary>
        void Render();
    }
}