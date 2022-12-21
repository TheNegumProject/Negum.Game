using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Negum.Game.Client;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Tasks;
using Negum.Game.Server;

namespace Negum.Game;

/// <summary>
/// Entry point for starting the game.
/// </summary>
public static class NegumRunner
{
    /// <summary>
    /// Convenient wrapper for Client startup procedure.
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    /// <param name="assembliesWithPacketHandlers">Additional assemblies with IPacketHandler implementations</param>
    public static async Task RunClientAsync(
        int port = default, 
        CancellationToken token = default,
        IEnumerable<Assembly>? assembliesWithPacketHandlers = default) =>
        await RunRunnableService<INegumClient>(port, token, assembliesWithPacketHandlers);

    /// <summary>
    /// Convenient wrapper for Server startup procedure.
    /// </summary>
    /// <param name="port"></param>
    /// <param name="token"></param>
    /// <param name="assembliesWithPacketHandlers">Additional assemblies with IPacketHandler implementations</param>
    public static async Task RunServerAsync(
        int port = default, 
        CancellationToken token = default,
        IEnumerable<Assembly>? assembliesWithPacketHandlers = default) =>
        await RunRunnableService<INegumServer>(port, token, assembliesWithPacketHandlers);
    
    private static async Task RunRunnableService<TRunnableService>(
        int port = default, 
        CancellationToken token = default,
        IEnumerable<Assembly>? assembliesWithPacketHandlers = default) 
        where TRunnableService : IRunnableService
    {
        foreach (var assembly in assembliesWithPacketHandlers ?? GetAdditionalAssemblies())
        {
            NegumGameContainer.RegisterPacketHandlers(assembly);
        }
        
        await NegumGameContainer.Resolve<TRunnableService>().RunAsync(port, token);
    }

    private static IEnumerable<Assembly> GetAdditionalAssemblies()
    {
        const string addonsDirName = "Negum_Addons";

        var addonsDir = new DirectoryInfo(addonsDirName);

        if (!addonsDir.Exists)
        {
            addonsDir.Create();
        }

        return addonsDir
            .GetFiles()
            .Select(fileInfo =>
            {
                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(fileInfo.FullName);
                    return Assembly.Load(assemblyName);
                }
                catch (Exception)
                {
                    return null;
                }
            })
            .Where(assembly => assembly is not null)
            .Cast<Assembly>()
            .ToList();
    }
}