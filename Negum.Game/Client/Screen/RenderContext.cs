using System.Collections;
using System.Collections.Generic;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Context which defines data required for rendering.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class RenderContext : IEnumerable<KeyValuePair<int, IEnumerable<SpriteContext>>>
    {
        /// <summary>
        /// Key used for gathering data for background layer.
        /// </summary>
        public const int BackgroundLayerKey = 0;

        /// <summary>
        /// Key used for gathering data for foreground layer.
        /// </summary>
        public const int ForegroundLayerKey = 1;

        /// <summary>
        /// Returns all sprites contexts from the specified layer.
        /// </summary>
        /// <param name="layer"></param>
        public IEnumerable<SpriteContext> this[int layer] => this.Layers[layer];

        /// <summary>
        /// Allows for setting global scaling value for the whole rendered single frame.
        /// </summary>
        public int Scale { get; set; } = 1;

        /// <summary>
        /// Sprites / Textures are always rendered from lower layer to the top layer (0 - N).
        /// As 0-indexed layer we can understand a background, where 1-indexed layer we can understand as foreground.
        /// </summary>
        protected IDictionary<int, IEnumerable<SpriteContext>> Layers { get; } =
            new Dictionary<int, IEnumerable<SpriteContext>>();

        public RenderContext()
        {
            // By default create required layers
            this.Layers.Add(BackgroundLayerKey, new List<SpriteContext>());
            this.Layers.Add(ForegroundLayerKey, new List<SpriteContext>());
        }

        /// <summary>
        /// Adds specified context to the desired layer.
        /// </summary>
        /// <param name="layer">Layer to which the context should be added. For most cases it will either be BackgroundLayerKey or ForegroundLayerKey.</param>
        /// <param name="ctx">Context which should be rendered on a desired layer.</param>
        public void AddSprite(int layer, SpriteContext ctx)
        {
            if (!this.Layers.ContainsKey(layer))
            {
                this.Layers.Add(layer, new List<SpriteContext>());
            }

            ((List<SpriteContext>) this.Layers[layer]).Add(ctx);
        }

        public IEnumerator<KeyValuePair<int, IEnumerable<SpriteContext>>> GetEnumerator() =>
            this.Layers.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}