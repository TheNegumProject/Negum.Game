using System.Threading.Tasks;
using Negum.Game.Common.Network;

namespace Negum.Game.Common
{
    /// <summary>
    /// Represent single connection side i.e. Client or Server.
    /// Contains common methods for all sides, like: Start or Stop.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface INegumSide
    {
        /// <summary>
        /// Represents packet handler connected with the current side.
        /// </summary>
        IPacketHandler PacketHandler { get; }
        
        /// <summary>
        /// Represents a network manager connected with the current side.
        /// </summary>
        INetworkManager NetworkManager { get; }

        /// <summary>
        /// Starts current side.
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Stops current side.
        /// </summary>
        Task StopAsync();
    }
}