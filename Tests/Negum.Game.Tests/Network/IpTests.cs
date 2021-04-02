using Negum.Game.Common.Network;
using Xunit;

namespace Negum.Game.Tests.Network
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
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