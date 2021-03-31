using Negum.Game.Common;

namespace Negum.Game.Server.Network
{
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