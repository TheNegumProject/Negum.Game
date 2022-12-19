using System;
using System.Net;
using Negum.Game.Common.Containers;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Contains information about currently connected server.
/// </summary>
public interface IServerConfiguration
{
    /// <summary>
    /// HostName to which client is currently connected.
    /// </summary>
    string HostName { get; }
    
    /// <summary>
    /// Port on which client is currently connected.
    /// </summary>
    int Port { get; }

    /// <summary>
    /// Saves connection details.
    /// </summary>
    /// <param name="hostname"></param>
    /// <param name="port"></param>
    void Connect(string hostname, int port);
}

public class ServerConfiguration : IServerConfiguration
{
    public ServerConfiguration()
    {
        var helper = NegumGameContainer.Resolve<INetworkHelper>();

        HostName = helper.GetLocalAddress();
        Port = helper.GetNextFreePort();
    }
    
    public string HostName { get; private set; }
    public int Port { get; private set; }

    public void Connect(string hostname, int port)
    { 
        if (port is < IPEndPoint.MinPort or > IPEndPoint.MaxPort)
        {
            throw new ArgumentException($"Wrong port number: {port}");
        }

        Port = port;
        HostName = hostname;
    }
}