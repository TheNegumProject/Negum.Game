using System.Collections.Generic;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Context which contains information about rendering of a single sprite.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class SpriteContext
    {
        /// <summary>
        /// Sprite which should be rendered.
        /// </summary>
        public IEnumerable<byte> Image { get; }

        /// <summary>
        /// Sprite's position X.
        /// </summary>
        public int PosX { get; }

        /// <summary>
        /// Sprite's position Y.
        /// </summary>
        public int PosY { get; }

        /// <summary>
        /// Sprite's width. 
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Sprite's height.
        /// </summary>
        public int Height { get; }

        public SpriteContext(IEnumerable<byte> image, int posX, int posY, int width, int height)
        {
            this.Image = image;
            this.PosX = posX;
            this.PosY = posY;
            this.Width = width;
            this.Height = height;
        }
    }
}