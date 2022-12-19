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
        
        writer.Write(packetType.Assembly.FullName ?? throw new NegumException($"Unknown assembly of Packet of type: {packetType.FullName}"));
        writer.Write(packetType.FullName ?? throw new NegumException($"Unknown Packet type"));
        
        packet.Write(stream);
        
        return stream.ToArray();
    }

    public IPacket Deserialize(byte[] packetData)
    {
        var stream = new MemoryStream(packetData, false);

        stream.Position = 0;
        
        var reader = new BinaryReader(stream);
        
        var assemblyFullName = reader.ReadString();
        var packetTypeFullName = reader.ReadString();
        
        var packetHandle = Activator.CreateInstanceFrom(assemblyFullName, packetTypeFullName);
        
        if (packetHandle?.Unwrap() is not IPacket packet)
        {
            throw new NegumException($"Cannot create an instance of Packet of type: [{nameof(assemblyFullName)}: {assemblyFullName}, {nameof(packetTypeFullName)}: {packetTypeFullName}]");
        }
        
        packet.Read(stream);
        
        return packet;
    }
}