using System.Threading.Tasks;
using Negum.Game.Server;
using Negum.Game.Tests.Runners.Common;

namespace Negum.Game.Tests.Runners.Server.Tcp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new NegumServerTcp(ConnectionContextMock.LocalHost);
            
            await server.StartAsync();
            await server.StopAsync();
        }
    }
}