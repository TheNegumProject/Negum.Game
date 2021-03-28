namespace Negum.Game.Common.Network
{
    /// <summary>
    /// Represents a context / settings used during connection.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IConnectionContext
    {
        /// <summary>
        /// Side specific:
        ///     - Client -> Represents a server to which the client wants to connect.
        ///     - Server -> Represents an IP on which the server is listening.
        /// </summary>
        string Hostname { get; }

        /// <summary>
        /// Side specific:
        ///     - Client -> Represents a port to which the client will try to connect.
        ///     - Server -> Represents a port on which the servers will be listening.
        /// </summary>
        int Port { get; }
    }

    public class ConnectionContext : IConnectionContext
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
    }
}