using System.IO;
using System.Threading.Tasks;
using Negum.Game.Common.Network;

namespace Negum.Game.Common.Packets
{
    /// <summary>
    /// Allows for easier working with reading and writing packet's data.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public abstract class SimplePacket : IPacket
    {
        public async Task ReadAsync(Stream stream)
        {
            var reader = new BinaryReader(stream);
            await this.ReadAsync(reader);
        }

        public async Task WriteAsync(Stream stream)
        {
            var writer = new BinaryWriter(stream);
            await this.WriteAsync(writer);
        }
        
        public abstract Task HandleAsync(IPacketHandler handler);

        /// <summary>
        /// Overrides default Read method providing BinaryReader for easier Stream manipulation.
        /// </summary>
        /// <param name="reader"></param>
        protected abstract Task ReadAsync(BinaryReader reader);
        
        /// <summary>
        /// Overrides default Write method providing BinaryWriter for easier Stream manipulation.
        /// </summary>
        /// <param name="writer"></param>
        protected abstract Task WriteAsync(BinaryWriter writer);
    }
}