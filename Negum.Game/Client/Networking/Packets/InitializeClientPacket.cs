using System.IO;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Client.Networking.Packets;

/// <summary>
/// Send when new Client is initialized.
/// </summary>
public class InitializeClientPacket : AbstractPacket
{
    public override void Read(BinaryReader reader)
    {
    }

    public override void Write(BinaryWriter writer)
    {
    }
}