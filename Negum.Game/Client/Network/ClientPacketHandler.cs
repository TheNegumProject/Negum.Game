using Negum.Game.Common;

namespace Negum.Game.Client.Network
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ClientPacketHandler : IClientPacketHandler
    {
        public INegumSide Side { get; }

        public ClientPacketHandler(INegumSide side)
        {
            this.Side = side;
        }
    }
}