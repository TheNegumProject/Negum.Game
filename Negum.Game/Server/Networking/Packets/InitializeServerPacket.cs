using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Server.Networking.Packets;

/// <summary>
/// Send when Server is initialized. <br />
/// <br />
/// NOTE: <br />
/// Keep in mind that it is send BEFORE server starts listening.
/// </summary>
public class InitializeServerPacket : AbstractPacket
{
}