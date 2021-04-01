using System.Threading.Tasks;
using Negum.Game.Client.Network;
using Negum.Game.Tests.Mocks;

namespace Negum.Game.Tests.Runners.Client.Tcp
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ClientNetworkManagerTcp(new NegumSideMock(), ConnectionContextMock.LocalHost);
            await client.ConnectAsync();

            var packetsToSend = 2;
            
            for (var i = 0; i < packetsToSend; ++i)
            {
                var packet = new PacketMock();
                await client.SendAsync(packet);
            }

            await client.DisconnectAsync();
        }
    }
}