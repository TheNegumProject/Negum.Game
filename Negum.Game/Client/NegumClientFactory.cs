using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Game.Common.Configurations;
using Negum.Game.Common.Network;

namespace Negum.Game.Client
{
    /// <summary>
    /// Factory which simplifies creation of default INegumClient.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public static class NegumClientFactory
    {
        /// <summary>
        /// </summary>
        /// <returns>New Negum Client object.</returns>
        /// <param name="negumDirPath">Path to the Negum directory.</param>
        /// <param name="ipAddress">IP address which will be used during the game. See: ISideConfiguration.ConnectionContext</param>
        /// <param name="port">Port which will be used during the game. See: IConnectionContext.Port</param>
        public static async Task<INegumClient> CreateAsync(string negumDirPath, string ipAddress = null, int port = -1)
        {
            var engineProvider = NegumContainer.Resolve<IEngineProvider>();
            var engine = await engineProvider.InitializeAsync(negumDirPath);

            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                ipAddress = NetworkHelper.GetLocalAddress();
            }

            if (port == -1)
            {
                port = NetworkHelper.GetNextFreePort();
            }

            var connectionContext = new ConnectionContext
            {
                Hostname = ipAddress,
                Port = port
            };

            var sideConfig = new SideConfiguration
            {
                ConnectionContext = connectionContext,
                Engine = engine
            };

            var client = new NegumClient(sideConfig);

            return client;
        }
    }
}