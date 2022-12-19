using System;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Indicates that the current PacketHandler should be called on specified side.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class PacketHandlerAttribute : Attribute
{
    public PacketHandlerAttribute(Side side)
    {
        Side = side;
    }
    
    /// <summary>
    /// Side for which the current Packet Handler should be called.
    /// </summary>
    public Side Side { get; }
}