using Negum.Game.Client.Input;
using Xunit;

namespace Negum.Game.Tests.Input
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class KeysTests
    {
        [Fact]
        public void Should_Register_Key_Pressing()
        {
            var keyBinding = new KeyBinding(44);
            
            keyBinding.OnKeyPressed(44); // Correct
            keyBinding.OnKeyPressed(45); // Wrong

            var clicks = 0;

            while (keyBinding.HandlePressed())
            {
                clicks++;
            }
            
            Assert.True(clicks == 1);
        }
    }
}