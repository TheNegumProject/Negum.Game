using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Common.Containers;

namespace Negum.Game.Client;

/// <summary>
/// Entry point for starting the Client.
/// </summary>
public static class NegumClientRunner
{
    /// <summary>
    /// Simple wrapper for Client startup procedure.
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    public static async Task RunAsync(int port = default, CancellationToken token = default) => 
        await NegumGameContainer.Resolve<INegumClient>().StartAsync(port, token);
}