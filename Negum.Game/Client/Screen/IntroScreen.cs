using Negum.Game.Client.Input;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class IntroScreen : AbstractScreen
    {
        public IntroScreen(INegumClient client) :
            base(client)
        {
        }

        public override void Setup(PlayerKeyBinding binding)
        {
            // TODO: Any key should skip intro
        }

        public override void Tick(double deltaTime)
        {
            // TODO: Update intro frame (???)
        }

        public override void Render()
        {
            // TODO: Render intro OR skip directly if none intro provided
        }
    }
}