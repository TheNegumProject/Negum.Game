using System.Threading;
using System.Threading.Tasks;

namespace Negum.Game.Common.Tasks;

/// <summary>
/// Identifies a service which could be run.
/// </summary>
public interface IRunnableService
{
    /// <summary>
    /// Starts the runnable service.
    /// </summary>
    /// <param name="port">Starts current service at specified port.</param>
    /// <param name="token">Token used for stopping the service</param>
    /// <returns></returns>
    Task RunAsync(int port = default, CancellationToken token = default);
}