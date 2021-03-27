using System.IO;
using System.Threading.Tasks;
using Negum.Game.Common.Network;

namespace Negum.Game.Common.Packets
{
    /// <summary>
    /// Describes root of the Packet communication tree.
    /// Packets are used to communicate between Client and Server.
    /// Each side (Client, Server) knows about all packets but each handles them differently.
    ///
    /// Each IPacket implementation class must have one constructor with no arguments !!!
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IPacket
    {
        /// <summary>
        /// Tries to read data from given input stream.
        /// </summary>
        /// <param name="stream"></param>
        Task ReadAsync(Stream stream);

        /// <summary>
        /// Tries to write data to the given output stream.
        /// </summary>
        /// <param name="stream"></param>
        Task WriteAsync(Stream stream);

        /// <summary>
        /// Provides a convenient way of calling appropriate handler to handle current packet.
        /// </summary>
        /// <param name="handler"></param>
        Task HandleAsync(IPacketHandler handler);
    }
}