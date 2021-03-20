using System.IO;

namespace Negum.Game.Common.Packets
{
    /// <summary>
    /// Describes root of the Packet communication tree.
    /// Packets are used to communicate between Client and Server.
    /// Each side (Client, Server) knows about all packets but each handles them differently.
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
        void Read(Stream stream);

        /// <summary>
        /// Tries to write data to the given output stream.
        /// </summary>
        /// <param name="stream"></param>
        void Write(Stream stream);
    }
}