using System.Net.Sockets;
using System.Threading.Tasks;
using Negum.Game.Common;
using Negum.Game.Common.Network;
using Negum.Game.Common.Packets;

namespace Negum.Game.Client.Network
{
    /// <summary>
    /// Represents a Client Network Manager which is using TCP protocol for connection.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ClientNetworkManagerTcp : AbstractNetworkManager, IClientNetworkManager
    {
        private TcpClient Client { get; }

        public ClientNetworkManagerTcp(INegumSide side, IConnectionContext ctx) :
            base(side, ctx)
        {
            this.Client = new TcpClient();
        }

        public override async Task ConnectAsync()
        {
            await this.Client.ConnectAsync(this.Context.Hostname, this.Context.Port);
        }

        public override async Task DisconnectAsync()
        {
            this.Client.Close();
        }

        public override async Task SendAsync(IPacket packet)
        {
            // TODO: If not yet connected, add given IPacket to some Queue and try sending it before next call.

            var stream = this.Client.GetStream();

            await this.SendPacketAsync(packet, stream);

            var serverPacket = await this.ReadPacketAsync(stream);
            await serverPacket.HandleAsync(this.Side.PacketHandler);
        }
    }
}