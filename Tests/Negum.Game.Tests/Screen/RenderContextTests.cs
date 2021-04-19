using System;
using System.Linq;
using Negum.Game.Client.Screen;
using Xunit;

namespace Negum.Game.Tests.Screen
{
    public class RenderContextTests
    {
        [Fact]
        public void Should_Add_And_Iterate_Over_Context_Values()
        {
            var ctx = new RenderContext();

            ctx.AddSprite(RenderContext.BackgroundLayerKey, GetRandomSpriteContext());
            ctx.AddSprite(RenderContext.BackgroundLayerKey, GetRandomSpriteContext());

            ctx.AddSprite(RenderContext.ForegroundLayerKey, GetRandomSpriteContext());
            ctx.AddSprite(RenderContext.ForegroundLayerKey, GetRandomSpriteContext());
            ctx.AddSprite(RenderContext.ForegroundLayerKey, GetRandomSpriteContext());

            Assert.True(ctx.Count() == 2);
            Assert.True(ctx[RenderContext.BackgroundLayerKey].Count() == 2);
            Assert.True(ctx[RenderContext.ForegroundLayerKey].Count() == 3);
        }

        private static SpriteContext GetRandomSpriteContext()
        {
            var random = new Random();

            var image = new byte[new Random().Next(1000)];
            random.NextBytes(image);

            var posX = random.Next(100);
            var posY = random.Next(100);
            var width = random.Next(100);
            var height = random.Next(100);

            return new SpriteContext(image, posX, posY, width, height);
        }
    }
}