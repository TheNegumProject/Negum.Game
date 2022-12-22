using Negum.Game.Common.Networking;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.States.Packets;

/// <summary>
/// Indicator for <see cref="IServerResponseBuilder"/> that the <see cref="GameState"/> should be returned to Client. <br />
/// By default implemented in <see cref="SyncStatePacket"/>.
/// </summary>
public interface ISyncStatePacket : IPacket
{
}

public class SyncStatePacket : AbstractPacket, ISyncStatePacket
{
}