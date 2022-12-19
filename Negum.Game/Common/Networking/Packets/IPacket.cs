using System.IO;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Packets are a core communication system between client and server. <br />
/// Each Packet should represent an atomic information. <br />
/// <br />
/// NOTE: <br />
/// Developers are free to use any kind of compression during packet reading / writing.
/// </summary>
public interface IPacket
{
    /// <summary>
    /// Reads packet data from the Stream.
    /// </summary>
    /// <param name="stream"></param>
    void Read(Stream stream);

    /// <summary>
    /// Writes packet data to the stream.
    /// </summary>
    /// <param name="stream"></param>
    void Write(Stream stream);
}