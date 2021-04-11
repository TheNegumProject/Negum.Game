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
        public INegumClient Client { get; }

        public AbstractScreen(INegumClient client)
        {
            this.Client = client;
        }

        public abstract void Setup();

        public abstract void Tick(double deltaTime);

        public abstract void Render();
    }
}