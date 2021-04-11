using System.Collections.Generic;
using Negum.Game.Client.Input;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Screen which represents Logo / Intro / Opening Video / etc.
    /// This screen should always set Main Menu Screen as the next one.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class IntroScreen : AbstractScreen
    {
        protected bool SkipIntro { get; set; }

        public IntroScreen(INegumClient client) :
            base(client)
        {
        }

        public override void Setup()
        {
            var playersBindings = new List<PlayerKeyBinding>
            {
                this.Client.Input.Player1Keys.Keys,
                this.Client.Input.Player2Keys.Keys
            };

            playersBindings.ForEach(binding =>
            {
                foreach (var key in binding.AllKeys)
                {
                    key.SetOnClick(this.DoSkip);
                }
            });
        }

        public override void Tick(double deltaTime)
        {
            if (this.SkipIntro) // TODO: This should also happen when animation / time ends.
            {
                this.Client.Screen.NextScreen(new MainMenuScreen(this.Client));
                return;
            }

            // TODO: Update intro frame (???)
        }

        public override void Render()
        {
            // TODO: Render intro OR skip directly if none intro provided
        }

        protected virtual void DoSkip()
        {
            this.SkipIntro = true;
        }
    }
}