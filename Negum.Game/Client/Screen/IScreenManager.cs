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
        /// <summary>
        /// Flag which indicates if Player is in GUI / Menu or if the match is in progress.
        /// 
        /// True - Any GUI is opened. It can either be a Menu screen or Pause screen (or some other GUI).
        /// False - Match is in progress.
        /// </summary>
        bool IsGuiOpened { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ScreenManger : ClientModule, IScreenManager
    {
        public bool IsGuiOpened { get; protected set; } = true; // TODO: Modify this value accordingly

        public override void Tick(double deltaTime)
        {
            // TODO: Handle Updating GUI and Match (i.e. character, stage, particles, etc.) - Just logic, not rendering
        }
    }
}