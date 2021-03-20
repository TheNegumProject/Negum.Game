using System.IO;

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
        public void Read(Stream stream)
        {
            var reader = new BinaryReader(stream);
            this.Read(reader);
        }

        public void Write(Stream stream)
        {
            var writer = new BinaryWriter(stream);
            this.Write(writer);
        }

        /// <summary>
        /// Overrides default Read method providing BinaryReader for easier Stream manipulation.
        /// </summary>
        /// <param name="reader"></param>
        protected abstract void Read(BinaryReader reader);
        
        /// <summary>
        /// Overrides default Write method providing BinaryWriter for easier Stream manipulation.
        /// </summary>
        /// <param name="writer"></param>
        protected abstract void Write(BinaryWriter writer);
    }
}