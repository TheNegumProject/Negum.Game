using System.Threading;
using Negum.Core.Engines;
using Negum.Game.Client.Input;
using Negum.Game.Client.Match;
using Negum.Game.Client.Screen;
using Negum.Game.Common;
using Negum.Game.Common.Network;

namespace Negum.Game.Client
{
    /// <summary>
    /// Represent a Client-side application.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface INegumClient : INegumSide
    {
        /// <summary>
        /// Thread on which the current Client was created.
        /// </summary>
        Thread CallerThread { get; }

        /// <summary>
        /// Context for local server connection.
        /// This should be used every time Client plays game that is not multiplayer-specific.
        /// </summary>
        IConnectionContext LocalServerContext { get; }

        /// <summary>
        /// FPS.
        /// </summary>
        int RefreshRate { get; }

        /// <summary>
        /// Engine used by current Client.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// Manager used to handle input.
        /// </summary>
        IInputManager Input { get; }

        /// <summary>
        /// Hooks which should be used for interoperability with the library.
        /// </summary>
        IClientHooks Hooks { get; }

        /// <summary>
        /// Manager used to handle screen-related logic.
        /// I.e. updating Camera position, zoom, particles position, etc.
        /// </summary>
        IScreenManager Screen { get; }

        /// <summary>
        /// Manager used to handle match-related logic.
        /// </summary>
        IMatchManager Match { get; }

        /// <summary>
        /// Manager used to handle rendering.
        /// </summary>
        IRenderManager Renderer { get; }
    }
}