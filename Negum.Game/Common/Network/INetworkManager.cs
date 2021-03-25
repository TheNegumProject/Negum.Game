using System.Threading.Tasks;
using Negum.Game.Common.Packets;

namespace Negum.Game.Common.Network
{
    /// <summary>
    /// Responsible for keeping up the connection with local or online server.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface INetworkManager
    {
        /// <summary>
        /// Side-object connected with this network manager.
        /// </summary>
        INegumSide Side { get; }

        /// <summary>
        /// Initializes the connection.
        /// </summary>
        /// <returns>True if the connection succeeded; otherwise false.</returns>
        Task<bool> ConnectAsync();

        /// <summary>
        /// Closes the connection.
        /// </summary>
        Task<bool> DisconnectAsync();

        /// <summary>
        /// Sends given packet.
        /// </summary>
        /// <param name="packet">Packet to send</param>
        Task SendAsync(IPacket packet);

        /// <summary>
        /// Handles received packet.
        /// </summary>
        /// <param name="packet"></param>
        Task ReceiveAsync(IPacket packet);
    }
}