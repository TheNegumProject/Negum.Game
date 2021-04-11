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

        public override void Setup(PlayerKeyBinding binding)
        {
            binding.A.SetOnClick(this.DoSkip);
            binding.B.SetOnClick(this.DoSkip);
            binding.C.SetOnClick(this.DoSkip);

            binding.Crouch.SetOnClick(this.DoSkip);
            binding.Jump.SetOnClick(this.DoSkip);
            binding.Left.SetOnClick(this.DoSkip);
            binding.Right.SetOnClick(this.DoSkip);
            binding.Start.SetOnClick(this.DoSkip);

            binding.X.SetOnClick(this.DoSkip);
            binding.Y.SetOnClick(this.DoSkip);
            binding.Z.SetOnClick(this.DoSkip);
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