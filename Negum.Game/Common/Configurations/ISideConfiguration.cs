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
        /// Client - Describes connection which should be used when playing on singleplayer.
        /// Server - Describes connection on which the server will be listening.
        /// </summary>
        IConnectionContext ConnectionContext { get; }
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class SideConfiguration : ISideConfiguration
    {
        public IConnectionContext ConnectionContext { get; set; }
    }
}