using System.Threading.Tasks;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Responsible for listening for incoming messages from clients.
/// </summary>
public interface IServerListener
{
    Task StartAsync();

    Task StopAsync();
}

public class ServerListener : IServerListener
{
    public Task StartAsync()
    {
        // TODO: Add logic
        return Task.CompletedTask;
    }

    public Task StopAsync()
    {
        // TODO: Add logic
        return Task.CompletedTask;
    }
}