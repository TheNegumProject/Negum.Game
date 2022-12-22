using System.IO;
using Negum.Game.Common.Networking.Packets;
using Negum.Game.Common.States.Packets;

namespace Negum.Game.Common.States;

/// <summary>
/// Stores all the information about current game. <br />
/// <br />
/// NOTES: <br />
/// 1. Implements IPacket as we want to send it to the Client in a response to <see cref="SyncStatePacket"/>. <br />
/// 2. Should have no effect on Server if send by Client
/// (technically someone could write a PacketHandler that will send it and process it on Server but "with great power comes great responsibility").
/// </summary>
public partial class GameState : AbstractPacket
{
    public override void Read(BinaryReader reader)
    {
    }

    public override void Write(BinaryWriter writer)
    {
    }
}