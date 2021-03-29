using Negum.Game.Common.Network;
using Xunit;

namespace Negum.Game.Tests.Network
{
    public class IpTests
    {
        [Fact]
        public void Should_Return_Local_IP_Address()
        {
            var localhost = NetworkHelper.GetLocalAddress();
            Assert.True(localhost != null);
        }
    }
}