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
        /// Setups given binding how each button should behave when the current screen is displayed.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="binding"></param>
        void Setup(INegumClient client, PlayerKeyBinding binding);

        /// <summary>
        /// Renders current screen.
        /// </summary>
        /// <param name="manager">Manager used to render current screen.</param>
        void Render(IRenderManager manager);
    }
}