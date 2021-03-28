using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common;
using Negum.Game.Common.Network;
using Negum.Game.Common.Packets;

namespace Negum.Game.Server.Network
{
    /// <summary>
    /// Represents a Server Network Manager which is using TCP protocol for listening.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ServerNetworkManagerTcp : AbstractNetworkManager, IServerNetworkManager
    {
        private TcpListener Listener { get; }
        private bool IsListening { get; set; }
        
        public ServerNetworkManagerTcp(INegumSide side, IConnectionContext context) : 
            base(side, context)
        {
            var ipAddress = IPAddress.Parse(this.Context.Hostname);
            this.Listener = new TcpListener(ipAddress, this.Context.Port);
        }

        public override async Task ConnectAsync()
        {
            this.Listener.Start();
            this.IsListening = true;
            await this.StartListeningLoop();
        }

        public override async Task DisconnectAsync()
        {
            this.Listener.Stop();
            this.IsListening = false;
        }

        public override async Task SendAsync(IPacket packet)
        {
        }

        protected virtual async Task StartListeningLoop()
        {
            while (this.IsListening)
            {
                var client = await this.Listener.AcceptTcpClientAsync();
                var stream = client.GetStream();
                
                var childTcpClientThread = new Thread(async () => await this.ProcessConnectionAsync(stream));
                childTcpClientThread.Start();
            }
        }

        private async Task ProcessConnectionAsync(Stream stream)
        {
            while (this.IsListening)
            {
                try
                {
                    var packet = await this.ReadPacketAsync(stream);
                    await packet.HandleAsync(this.Side.PacketHandler);
                    await this.SendPacketAsync(packet, stream);
                }
                catch (EndOfStreamException exception)
                {
                    /*
                     * TODO: Find better / cleaner solution instead of hard try-catch
                     * 
                     * This point will be hit when User disconnect.
                     * It will try to ReadPacketAsync and fail to read beyond stream end.
                     * 
                     * (It always pause when reading assemblyName in ReadPacketAsync, this is what's crashing
                     * when User disconnects.)
                     */
                    
                    break;
                }
            }
        }
    }
}