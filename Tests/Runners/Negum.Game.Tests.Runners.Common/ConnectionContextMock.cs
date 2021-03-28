using Negum.Game.Common.Network;

namespace Negum.Game.Tests.Runners.Common
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public static class ConnectionContextMock
    {
        /// <summary>
        /// Localhost context used for testing local server connectivity.
        /// </summary>
        public static IConnectionContext LocalHost { get; } = new ConnectionContext
        {
            Hostname = "192.168.0.11",
            Port = 9876
        };
    }
}