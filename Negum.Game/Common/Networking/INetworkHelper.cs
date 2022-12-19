using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Contains various network-related methods.
/// </summary>
public interface INetworkHelper
{
    /// <summary>
    /// </summary>
    /// <returns>Localhost address.</returns>
    string GetLocalAddress();

    /// <summary>
    /// </summary>
    /// <returns>Next free port.</returns>
    int GetNextFreePort();
}

public class NetworkHelper : INetworkHelper
{
    public string GetLocalAddress()
    {
        var hostname = Dns.GetHostName();
        var hostEntry = Dns.GetHostEntry(hostname);
        var addresses = hostEntry.AddressList;
        var localhost = addresses.First(address => address.ToString().StartsWith("192"));
        var localIp = localhost.ToString();

        return localIp;
    }

    public int GetNextFreePort()
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