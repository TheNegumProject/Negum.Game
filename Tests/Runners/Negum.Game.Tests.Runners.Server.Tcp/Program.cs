using System.Threading.Tasks;
using Negum.Game.Server;
using Negum.Game.Tests.Mocks;

namespace Negum.Game.Tests.Runners.Server.Tcp
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
            var server = new NegumServerTcp(SideConfigurationMock.Configuration);
            
            await server.StartAsync();
            await server.StopAsync();
        }
    }
}