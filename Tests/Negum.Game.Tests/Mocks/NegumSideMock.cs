using System.Threading.Tasks;
using Negum.Game.Common;
using Negum.Game.Common.Network;

namespace Negum.Game.Tests.Mocks
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class NegumSideMock : INegumSide
    {
        public IPacketHandler PacketHandler { get; set; }
        public INetworkManager NetworkManager { get; set; }
        
        public async Task StartAsync()
        {
        }

        public async Task StopAsync()
        {
        }
    }
}