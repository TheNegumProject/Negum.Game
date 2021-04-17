using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

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

        /// <summary>
        /// </summary>
        /// <returns>Next free port.</returns>
        /// <exception cref="SystemException"></exception>
        public static int GetNextFreePort()
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();

            var tcpListeners = properties.GetActiveTcpListeners();
            var udpListeners = properties.GetActiveUdpListeners();

            var occupiedPorts = tcpListeners.Select(p => p.Port).ToList();
            occupiedPorts.AddRange(udpListeners.Select(p => p.Port).ToList());

            for (var port = IPEndPoint.MaxPort; port > IPEndPoint.MinPort; --port)
            {
                if (!occupiedPorts.Contains(port))
                {
                    return port;
                }
            }

            throw new SystemException($"Cannot find any available port.");
        }
    }
}