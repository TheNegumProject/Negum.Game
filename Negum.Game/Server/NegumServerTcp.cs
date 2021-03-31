using System.Threading.Tasks;
using Negum.Game.Common.Network;
using Negum.Game.Server.Network;

namespace Negum.Game.Server
{
    /// <summary>
    /// Server implementation using TCP communication channel.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class NegumServerTcp : INegumServer
    {
        public IPacketHandler PacketHandler { get; }
        public INetworkManager NetworkManager { get; }

        public NegumServerTcp(IConnectionContext connectionContext)
        {
            this.PacketHandler = new ServerPacketHandler(this);
            this.NetworkManager = new ServerNetworkManagerTcp(this, connectionContext);
        }
        
        public async Task StartAsync()
        {
            await this.NetworkManager.ConnectAsync();
        }

        public async Task StopAsync()
        {
            await this.NetworkManager.DisconnectAsync();
        }
    }
}