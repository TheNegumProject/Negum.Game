using Negum.Game.Common.Configurations;

namespace Negum.Game.Tests.Mocks
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public static class SideConfigurationMock
    {
        /// <summary>
        /// Used to test local connection between Client and Server.
        /// </summary>
        public static ISideConfiguration Configuration { get; } = new SideConfiguration
        {
            ConnectionContext = ConnectionContextMock.LocalHost
        };
    }
}