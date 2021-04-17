using System.Net;
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

        [Fact]
        public void Should_Return_Next_Free_Port()
        {
            var port = NetworkHelper.GetNextFreePort();

            Assert.True(port >= IPEndPoint.MinPort);
            Assert.True(port <= IPEndPoint.MaxPort);
        }
    }
}