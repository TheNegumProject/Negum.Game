using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Negum.Core.Exceptions;
using Negum.Game.Common.Extensions;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Stores information about all currently known Packet Handlers.
/// </summary>
public interface IPacketHandlerRegistry
{
    /// <summary>
    /// Registers all classes of type <see cref="IPacketHandler{TPacket}"/> from specified <see cref="Assembly"/>.
    /// </summary>
    /// <param name="assembly"></param>
    void RegisterPacketHandlers(Assembly assembly);

    /// <summary>
    /// </summary>
    /// <param name="side">Side for which PacketHandlers should be returned.</param>
    /// <typeparam name="TPacket">Packet for which PacketHandlers should be returned.</typeparam>
    /// <returns>Returns a snapshot of currently registered PacketHandlers.</returns>
    IEnumerable<IPacketHandler<TPacket>> GetPacketHandlers<TPacket>(Side side) // TODO: remove generic type
        where TPacket : IPacket;
}

public class PacketHandlerRegistry : IPacketHandlerRegistry
{
    private static ICollection<PacketHandlerRegistryEntry> Entries { get; } = new HashSet<PacketHandlerRegistryEntry>();

    public void RegisterPacketHandlers(Assembly assembly)
    {
        assembly.GetTypes()
            .Where(type => type.IsPacketHandler())
            .ToList()
            .ForEach(ProcessPacketHandlerType);
    }

    public IEnumerable<IPacketHandler<TPacket>> GetPacketHandlers<TPacket>(Side side) 
        where TPacket : IPacket =>
        Entries
            .Single(en => en.Side == side)
            .GetPacketHandlers<TPacket>();

    private static void ProcessPacketHandlerType(Type packetHandlerClassType)
    {
        var packetHandlerInstance = Activator.CreateInstance(packetHandlerClassType);
        
        if (packetHandlerInstance is null)
        {
            throw new NegumException($"Cannot create an instance of '{packetHandlerClassType.Name}'.");
        }

        var packetHandlerInterfaceTypes = packetHandlerClassType.GetPacketHandlerTypes();

        var packetTypes = packetHandlerInterfaceTypes
            .Select(packetHandlerInterfaceType => packetHandlerInterfaceType.GetGenericArguments().First())
            .ToList();
        
        var supportedSides = packetHandlerClassType
            .GetCustomAttributes<PacketHandlerAttribute>()
            .Select(attr => attr.Side)
            .Distinct()
            .ToList();

        foreach (var supportedSide in supportedSides) // i.e.: Client
        {
            foreach (var packetType in packetTypes) // i.e.: MyPacket
            {
                if (Entries.All(entry => entry.Side != supportedSide))
                {
                    Entries.Add(new PacketHandlerRegistryEntry(supportedSide));
                }

                var entry = Entries.Single(en => en.Side == supportedSide);
                
                entry.AddPacketHandler(packetType, packetHandlerInstance);
            }
        }
    }
}

public class PacketHandlerRegistryEntry
{ 
    internal PacketHandlerRegistryEntry(Side side)
    {
        Side = side;
    }
    
    public Side Side { get; }
    
    /// <summary>
    /// Key - Packet Type
    /// Value - Collection of PacketHandler instances handling related PacketType
    /// </summary>
    private IDictionary<Type, ICollection<object>> Handlers { get; } = new ConcurrentDictionary<Type, ICollection<object>>();

    public void AddPacketHandler(Type packetType, object packetHandlerInstance)
    {
        if (!Handlers.ContainsKey(packetType))
        {
            Handlers.Add(packetType, new HashSet<object>());
        }
        
        Handlers[packetType].Add(packetHandlerInstance);
    }

    public IEnumerable<IPacketHandler<TPacket>> GetPacketHandlers<TPacket>() 
        where TPacket : IPacket => 
        Handlers.ContainsKey(typeof(TPacket)) 
            ? Handlers[typeof(TPacket)]
                .Cast<IPacketHandler<TPacket>>()
                .ToList()
                .AsReadOnly() 
            : Array.Empty<IPacketHandler<TPacket>>();
}