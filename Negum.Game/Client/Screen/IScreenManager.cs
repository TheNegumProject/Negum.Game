using System.Collections.Generic;

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
        /// Sets next screen to be displayed.
        /// </summary>
        /// <param name="screen">New screen</param>
        void NextScreen(IScreen screen);

        /// <summary>
        /// Goes to previous Screen.
        /// I.e. goes from Options screen to Menu screen.
        /// </summary>
        void GoToPreviousScreen();
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ScreenManager : ClientModule, IScreenManager
    {
        /// <summary>
        /// Stacks Screens which Player entered.
        /// </summary>
        protected Stack<IScreen> ScreenStack { get; } = new();

        public IScreen CurrentScreen => this.ScreenStack.Peek();

        public override void Initialize()
        {
            // At first we want to display Intro Screen
            this.NextScreen(new IntroScreen(this.Client));
        }

        public void NextScreen(IScreen screen)
        {
            this.ScreenStack.Push(screen);
            this.ClearKeysLogic();
            this.CurrentScreen.Setup();
        }

        public void GoToPreviousScreen()
        {
            this.ScreenStack.Pop();
            this.ClearKeysLogic();
            this.CurrentScreen.Setup();
        }

        protected virtual void ClearKeysLogic()
        {
            if (this.Client == null)
            {
                return;
            }

            var playersBindings = new[]
            {
                this.Client.Input.Player1Keys.Keys,
                this.Client.Input.Player2Keys.Keys
            };

            foreach (var binding in playersBindings)
            {
                binding.ClearKeysLogic();
            }
        }
    }
}