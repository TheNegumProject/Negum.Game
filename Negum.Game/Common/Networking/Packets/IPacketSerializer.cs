using System;
using System.IO;
using Negum.Core.Exceptions;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Responsible for serializing / deserializing Packets.
/// </summary>
public interface IPacketSerializer
{
    /// <summary>
    /// </summary>
    /// <param name="packet">Packet to be serialized.</param>
    /// <returns>Serialized Packet.</returns>
    byte[] Serialize(IPacket packet);

    /// <summary>
    /// </summary>
    /// <param name="packetData">Packet data to be deserialized.</param>
    /// <returns>Deserialized Packet.</returns>
    IPacket Deserialize(byte[] packetData);
}

public class PacketSerializer : IPacketSerializer
{
    public byte[] Serialize(IPacket packet)
    {
        var stream = new MemoryStream();
        var writer = new BinaryWriter(stream);
        var packetType = packet.GetType();
        
        writer.Write(packetType.AssemblyQualifiedName ?? throw new NegumException($"Cannot determine Packet type assembly qualified name: {packetType}"));
        
        packet.Write(stream);
        
        return stream.ToArray();
    }

    public IPacket Deserialize(byte[] packetData)
    {
        var stream = new MemoryStream(packetData, false);

        stream.Position = 0;
        
        var reader = new BinaryReader(stream);
        var assemblyQualifiedName = reader.ReadString(); 
        var packetType = Type.GetType(assemblyQualifiedName) ?? throw new NegumException($"Cannot find type: '{assemblyQualifiedName}'");
        var packetInstance = Activator.CreateInstance(packetType);

        if (packetInstance is not IPacket packet)
        {
            throw new NegumException($"Packet type '{packetType}' is not a valid IPacket implementation.");
        }
        
        packet.Read(stream);
        
        return packet;
    }
}