using Negum.Game.Common;

namespace Negum.Game.Server
{
    /// <summary>
    /// Represent a Server-side service.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface INegumServer : INegumSide
    {
        // TODO: Add ServerState as an object which will be used to sync Players.
        // TODO: There should also be some Packet for that like: SyncDataPacket which will take ServerState as an argument.
    }
}