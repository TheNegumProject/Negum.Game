using System.Linq;
using System.Net;

namespace Negum.Game.Common.Network
{
    /// <summary>
    /// Contains various helper methods related to network.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public static class NetworkHelper
    {
        /// <summary>
        /// </summary>
        /// <returns>Returns local IP.</returns>
        public static string GetLocalAddress()
        {
            var hostname = Dns.GetHostName();
            var hostEntry = Dns.GetHostEntry(hostname);
            var addresses = hostEntry.AddressList;
            var localhost = addresses.FirstOrDefault(address => address.ToString().StartsWith("192"));
            var localIp = localhost?.ToString();
            
            return localIp;
        }
    }
}