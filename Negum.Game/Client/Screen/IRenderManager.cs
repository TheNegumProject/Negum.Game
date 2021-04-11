namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Manager used to handle rendering.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IRenderManager : IClientModule
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class RenderManager : ClientModule, IRenderManager
    {
        public override void Tick(double deltaTime)
        {
            // TODO: Render GUI, Stage, Players, Particles, etc.

            this.Client.Screen.CurrentScreen.Render();
        }
    }
}