using Negum.Game.Common;

namespace Negum.Game.Client.Network
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ClientPacketHandler : ClientModule, IClientPacketHandler
    {
        public INegumSide Side => this.Client;
    }
}