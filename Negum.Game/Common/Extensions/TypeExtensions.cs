using System;
using System.Collections.Generic;
using System.Linq;
using Negum.Game.Common.Networking;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Extensions;

public static class TypeExtensions
{
    public static bool IsPacketHandler(this Type type) => 
        type.ImplementsGenericInterface(typeof(IPacketHandler<>));

    public static bool ImplementsGenericInterface(this Type type, Type genericInterfaceType) =>
        type.GetInterfaces()
            .Any(iface => iface.IsGenericType 
                          && iface.GetGenericTypeDefinition().IsAssignableTo(genericInterfaceType));

    public static IEnumerable<Type> GetPacketHandlerTypes(this Type type) =>
        type.GetGenericInterfaces(typeof(IPacketHandler<>));

    public static IEnumerable<Type> GetGenericInterfaces(this Type type, Type genericInterfaceType)
    {
        var foundTypes = type.GetInterfaces()
            .Where(iface => iface.GetGenericTypeDefinition() == genericInterfaceType)
            .ToList();

        if (type.BaseType is not null)
        {
            foundTypes.AddRange(type.BaseType.GetGenericInterfaces(genericInterfaceType));
        }

        return foundTypes;
    }
}