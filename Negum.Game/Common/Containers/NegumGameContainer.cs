using System;
using System.Reflection;
using Negum.Core.Containers;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Containers;

/// <summary>
/// Container used in Negum.Game project.
/// Contains wrappers for <see cref="NegumContainer"/>.
/// </summary>
public static class NegumGameContainer
{
    static NegumGameContainer()
    {
        // Register all interface-class pairs in Negum.Game namespace
        RegisterInterfaceClassPairs("Negum.Game", typeof(NegumGameContainer));
        
        // Register all PacketHandlers from current project
        RegisterPacketHandlers(typeof(NegumGameContainer).Assembly);
    }
    
    /// <summary>
    /// Convenient wrapper for <see cref="NegumContainer.Register"/>
    /// </summary>
    /// <param name="interfaceType"></param>
    /// <param name="implementationType"></param>
    /// <param name="lifetime"></param>
    public static void Register(Type interfaceType, Type implementationType, NegumObjectLifetime lifetime = NegumObjectLifetime.Transient) => 
        NegumContainer.Register(interfaceType, implementationType, lifetime);

    /// <summary>
    /// Convenient wrapper for <see cref="NegumContainer.Register{TInterface,TClass}"/>
    /// </summary>
    /// <param name="lifetime"></param>
    /// <typeparam name="TInterface"></typeparam>
    /// <typeparam name="TClass"></typeparam>
    public static void Register<TInterface, TClass>(NegumObjectLifetime lifetime = NegumObjectLifetime.Transient)
        where TClass : class, TInterface =>
        NegumContainer.Register<TInterface, TClass>(lifetime);

    /// <summary>
    /// Convenient wrapper for <see cref="NegumContainer.Resolve{TInterface}"/>
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <returns></returns>
    public static TInterface Resolve<TInterface>() =>
        NegumContainer.Resolve<TInterface>();

    /// <summary>
    /// Convenient wrapper for <see cref="NegumContainer.RegisterInterfaceClassPairs"/>
    /// </summary>
    /// <param name="namespace"></param>
    /// <param name="rootType"></param>
    public static void RegisterInterfaceClassPairs(string? @namespace, Type rootType) =>
        NegumContainer.RegisterInterfaceClassPairs(@namespace, rootType);

    /// <summary>
    /// Registers all Packet Handlers from specified <see cref="Assembly"/>
    /// </summary>
    /// <param name="assembly"></param>
    public static void RegisterPacketHandlers(Assembly assembly)
    {
        var packetRegistry = Resolve<IPacketHandlerRegistry>();
        packetRegistry.RegisterPacketHandlers(assembly);
    }
}