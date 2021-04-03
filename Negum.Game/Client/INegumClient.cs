using System.Threading;
using Negum.Core.Engines;
using Negum.Game.Client.Input;
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
        InputManager Input { get; }
        
        /// <summary>
        /// Hooks which should be used for interoperability with the library.
        /// </summary>
        ClientHooks Hooks { get; }
    }
}