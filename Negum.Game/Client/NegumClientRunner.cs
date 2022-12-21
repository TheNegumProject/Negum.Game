using System.Collections.Generic;
using System.Reflection;
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
    /// Convenient wrapper for Client startup procedure.
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    /// <param name="assembliesWithPacketHandlers">Additional assemblies with IPacketHandler implementations</param>
    public static async Task RunAsync(
        int port = default, 
        CancellationToken token = default,
        IEnumerable<Assembly>? assembliesWithPacketHandlers = default)
    {
        foreach (var assembly in assembliesWithPacketHandlers ?? new List<Assembly>())
        {
            NegumGameContainer.RegisterPacketHandlers(assembly);
        }
        
        await NegumGameContainer.Resolve<INegumClient>().RunAsync(port, token);
    }
}