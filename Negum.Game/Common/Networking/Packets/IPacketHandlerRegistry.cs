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
    /// <param name="packet">Packet for which PacketHandlers should be returned.</param>
    /// <returns>Returns a snapshot of currently registered PacketHandlers.</returns>
    IEnumerable<object> GetPacketHandlers(IPacket packet, Side side);
}

public class PacketHandlerRegistry : IPacketHandlerRegistry
{
    private static ICollection<PacketHandlerRegistryEntry> Entries { get; } = new HashSet<PacketHandlerRegistryEntry>();

    public virtual void RegisterPacketHandlers(Assembly assembly)
    {
        assembly.GetTypes()
            .Where(type => type.IsPacketHandler())
            .ToList()
            .ForEach(ProcessPacketHandlerType);
    }

    public virtual IEnumerable<object> GetPacketHandlers(IPacket packet, Side side) =>
        Entries
            .SingleOrDefault(en => en.Side == side)?
            .GetPacketHandlers(packet)
        ?? new List<object>(); // Special case when we don't have local server running yet

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
    public PacketHandlerRegistryEntry(Side side)
    {
        Side = side;
    }
    
    public Side Side { get; }
    
    /// <summary>
    /// Key - Packet Type
    /// Value - Collection of PacketHandler instances handling related PacketType
    /// </summary>
    private IDictionary<Type, ICollection<object>> Handlers { get; } = new ConcurrentDictionary<Type, ICollection<object>>();

    public virtual void AddPacketHandler(Type packetType, object packetHandlerInstance)
    {
        if (!Handlers.ContainsKey(packetType))
        {
            Handlers.Add(packetType, new HashSet<object>());
        }
        
        Handlers[packetType].Add(packetHandlerInstance);
    }

    public virtual IEnumerable<object> GetPacketHandlers(IPacket packet) => 
        Handlers.ContainsKey(packet.GetType()) 
            ? Handlers[packet.GetType()]
                .ToList()
                .AsReadOnly() 
            : Array.Empty<object>();
}