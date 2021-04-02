using System;
using Xunit;

namespace Negum.Game.Tests.Rendering
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class FpsTests
    {
        [Theory]
        [InlineData(60.0)]
        public void Should_Render_In_N_Fps(float fpsCount/*, int numberOfRefreshes, int updateCount, int renderCount*/)
        {
            int updateCounts = 0;
            int renderCounts = 0;
            
            TimeSpan deltaTime;
            DateTime oldTime = DateTime.Now;
            double accumulator = 0;
            
            for (var i = 0; i < 10; ++i) // while (running) simulation
            {
                deltaTime = DateTime.Now - oldTime;
                oldTime = DateTime.Now;
                accumulator += deltaTime.TotalMilliseconds;

                while (accumulator > 1.0 / fpsCount)
                {
                    updateCounts++; // call update()
                    accumulator -= 1.0 / fpsCount;
                }

                renderCounts++; // call render()
            }
            
            Assert.True(updateCounts > renderCounts);
        }
    }
}