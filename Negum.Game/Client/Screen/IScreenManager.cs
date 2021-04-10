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
        /// Screen which is currently being used / rendered.
        /// I.e. Menu, Character Selection, Options, Match, etc.
        /// </summary>
        IScreen CurrentScreen { get; }

        /// <summary>
        /// Sets new screen to be displayed.
        /// </summary>
        /// <param name="screen">New screen</param>
        void SetScreen(IScreen screen);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ScreenManger : ClientModule, IScreenManager
    {
        public IScreen CurrentScreen { get; protected set; }

        public void SetScreen(IScreen screen)
        {
            this.CurrentScreen = screen;

            // TODO: Add support for more Players

            this.CurrentScreen.Setup(this.Client, this.Client.Input.Player1Keys.Keys);
            this.CurrentScreen.Setup(this.Client, this.Client.Input.Player2Keys.Keys);
        }
    }
}