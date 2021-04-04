namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Manager which is use to handle screen-related logic.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IScreenManager : IClientModule
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ScreenManger : ClientModule, IScreenManager
    {
        public override void Tick(double deltaTime)
        {
            // TODO: Handle Updating GUI and Match (i.e. character, stage, particles, etc.) - Just logic, not rendering
        }
    }
}