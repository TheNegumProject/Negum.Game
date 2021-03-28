using System.Threading.Tasks;
using Negum.Game.Server.Network;
using Negum.Game.Tests.Mocks;
using Negum.Game.Tests.Runners.Common;

namespace Negum.Game.Tests.Runners.Server.Tcp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new ServerNetworkManagerTcp(new NegumSideMock(), ConnectionContextMock.LocalHost);
            await server.ConnectAsync();
            await server.DisconnectAsync();
        }
    }
}