using Negum.Game.Common;
using Negum.Game.Common.Network;

namespace Negum.Game.Server.Network
{
    /// <summary>
    /// Responsible for handling only Server-side packets.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IServerPacketHandler : IPacketHandler
    {
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ServerPacketHandler : IServerPacketHandler
    {
        public INegumSide Side { get; }

        public ServerPacketHandler(INegumSide side)
        {
            this.Side = side;
        }
    }
}