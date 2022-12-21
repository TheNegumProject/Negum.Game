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
    /// Indicates whether the local server is up and running.
    /// </summary>
    bool IsLocalServerRunning { get; }

    /// <summary>
    /// Saves connection details.
    /// </summary>
    /// <param name="hostname"></param>
    /// <param name="port"></param>
    void Connect(string hostname, int port);

    /// <summary>
    /// Connects to local server aka localhost.
    /// </summary>
    void ConnectToLocalServer();

    /// <summary>
    /// Used for setting up flag that local server is running.
    /// </summary>
    void ToggleLocalServerRunning();
}

public class ServerConfiguration : IServerConfiguration
{
    public string HostName { get; private set; } = "localhost";
    public int Port { get; private set; }
    public bool IsLocalServerRunning { get; private set; }

    /// <summary>
    /// Stores information about local hostname ("localhost" or IP)
    /// </summary>
    private string LocalHostName { get; set; } = "localhost";

    /// <summary>
    /// Stores information about local server port.
    /// </summary>
    private int LocalPort { get; set; }

    public ServerConfiguration()
    {
    }

    public virtual void Connect(string hostname, int port)
    { 
        if (port is < IPEndPoint.MinPort or > IPEndPoint.MaxPort)
        {
            throw new ArgumentException($"Wrong port number: {port}");
        }

        Port = port;
        HostName = hostname;
    }

    public virtual void ConnectToLocalServer()
    {
        if (LocalPort == default)
        {
            var helper = NegumGameContainer.Resolve<INetworkHelper>();

            LocalHostName = helper.GetLocalAddress();
            LocalPort = helper.GetNextFreePort();
        }

        Connect(LocalHostName, LocalPort);
    }

    public void ToggleLocalServerRunning() => 
        IsLocalServerRunning = true;
}