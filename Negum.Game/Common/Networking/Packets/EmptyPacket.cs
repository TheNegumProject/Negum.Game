using System.IO;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Empty Packet which should not be handled by any handler.
/// </summary>
public class EmptyPacket : AbstractPacket
{
    public override void Read(BinaryReader reader)
    {
    }

    public override void Write(BinaryWriter writer)
    {
    }
}