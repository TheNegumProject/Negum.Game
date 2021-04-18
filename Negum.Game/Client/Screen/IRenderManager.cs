using System;

namespace Negum.Game.Client.Screen
{
    /// <summary>
    /// Manager used to handle rendering.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IRenderManager : IClientModule
    {
        /// <summary>
        /// Renders sprites / textures to screen.
        /// </summary>
        /// <param name="callback">Callback which will be used to render sprites.</param>
        void Render(Action<RenderContext> callback);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class RenderManager : ClientModule, IRenderManager
    {
        public virtual void Render(Action<RenderContext> callback)
        {
            var ctx = new RenderContext();

            this.Client.Screen.CurrentScreen.Render(ctx);

            callback?.Invoke(ctx);
        }
    }
}