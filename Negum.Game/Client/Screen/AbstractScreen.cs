using Negum.Game.Client.Input;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Contains common logic for all screens.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public abstract class AbstractScreen : IScreen
    {
        public abstract void Setup(INegumClient client, PlayerKeyBinding binding);

        public abstract void Render(IRenderManager manager);
    }
}