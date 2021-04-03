using System.Threading;
using Negum.Core.Engines;
using Negum.Game.Common.Network;

namespace Negum.Game.Common.Configurations
{
    /// <summary>
    /// Represents a configuration used to create Client and Server.
    ///
    /// NOTE:
    /// Some properties may have different meaning on Client or Server side.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface ISideConfiguration
    {
        /// <summary>
        /// Thread which created current object and started it.
        /// By default it will use: Thread.CurrentThread called when creating a configuration object. 
        /// </summary>
        Thread CallerThread { get; }
        
        /// <summary>
        /// Client - Describes connection which should be used when playing on singleplayer.
        /// Server - Describes connection on which the server will be listening.
        /// </summary>
        IConnectionContext ConnectionContext { get; }
        
        /// <summary>
        /// Client - Describes the refresh rate (FPS).
        /// 120 FPS by default.
        /// </summary>
        int FrameRate { get; }
        
        /// <summary>
        /// Engine used by the current side (Client / Server).
        /// </summary>
        IEngine Engine { get; }
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class SideConfiguration : ISideConfiguration
    {
        public Thread CallerThread { get; set; } = Thread.CurrentThread;
        public IConnectionContext ConnectionContext { get; set; }
        public int FrameRate { get; set; } = 120; // Default 120 FPS
        public IEngine Engine { get; set; }
    }
}