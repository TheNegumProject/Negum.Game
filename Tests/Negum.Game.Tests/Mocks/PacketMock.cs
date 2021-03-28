using System.IO;
using System.Threading.Tasks;
using Negum.Game.Common.Network;
using Negum.Game.Common.Packets;
using Xunit;

namespace Negum.Game.Tests.Mocks
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class PacketMock : SimplePacket
    {
        private const int SomeValue = 123;
        
        public override async Task HandleAsync(IPacketHandler handler)
        {
        }

        protected override async Task ReadAsync(BinaryReader reader)
        {
            var data = reader.ReadInt32();
            Assert.True(data == SomeValue);
        }

        protected override async Task WriteAsync(BinaryWriter writer)
        {
            writer.Write(SomeValue);
        }
    }
}