using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Game.Common.Packets;

namespace Negum.Game.Common.Network
{
    /// <summary>
    /// Responsible for keeping up the connection with local or online server.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface INetworkManager
    {
        /// <summary>
        /// Side-object connected with this network manager.
        /// </summary>
        INegumSide Side { get; }

        /// <summary>
        /// Initializes the connection.
        /// </summary>
        Task ConnectAsync();

        /// <summary>
        /// Closes the connection.
        /// </summary>
        Task DisconnectAsync();

        /// <summary>
        /// Sends given packet.
        /// </summary>
        /// <param name="packet">Packet to send</param>
        Task SendAsync(IPacket packet);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public abstract class AbstractNetworkManager : INetworkManager
    {
        public INegumSide Side { get; }
        public IConnectionContext Context { get; }

        protected AbstractNetworkManager(INegumSide side, IConnectionContext context)
        {
            this.Side = side;
            this.Context = context;
        }

        public abstract Task ConnectAsync();

        public abstract Task DisconnectAsync();

        public abstract Task SendAsync(IPacket packet);

        protected virtual async Task<byte[]> WritePacketAsync(IPacket packet)
        {
            var memoryStream = new MemoryStream();
            var writer = new BinaryWriter(memoryStream);

            writer.Write(packet.GetType().Assembly.FullName);
            writer.Write(packet.GetType().ToString());

            await packet.WriteAsync(memoryStream);
            
            var packetData = memoryStream.ToArray();

            return packetData;
        }

        protected virtual async Task<IPacket> ReadPacketAsync(Stream stream)
        {
            var reader = new BinaryReader(stream);

            var assemblyName = reader.ReadString();
            var packetClassType = reader.ReadString();

            var objectHandle = Activator.CreateInstance(assemblyName, packetClassType);
            var packet = objectHandle.Unwrap() as IPacket;
            await packet.ReadAsync(stream);

            return packet;
        }

        protected virtual async Task SendPacketAsync(IPacket packet, Stream stream)
        {
            var packetData = await this.WritePacketAsync(packet);
            
            await stream.WriteAsync(packetData, 0, packetData.Length);
        }
    }
}