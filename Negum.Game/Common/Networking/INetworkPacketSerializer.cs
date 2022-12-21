using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Negum.Core.Exceptions;
using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Common.Networking;

/// <summary>
/// Serializer responsible for handling serializing and deserializing Packets via network.
/// </summary>
public interface INetworkPacketSerializer
{
    /// <summary>
    /// Reads Packet from the given Stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<IPacket> ReadAsync(Stream stream, CancellationToken token = default);

    /// <summary>
    /// Writes Packet into Stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="packet"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task WriteAsync(Stream stream, IPacket packet, CancellationToken token = default);
}

public class NetworkPacketSerializer : INetworkPacketSerializer
{
    public async Task<IPacket> ReadAsync(Stream stream, CancellationToken token = default)
    {
        var lengthBytes = new byte[sizeof(int)];
        var readBytes = await stream.ReadAsync(lengthBytes, token);

        if (readBytes != lengthBytes.Length)
        {
            throw new NegumException("Cannot read Packet size.");
        }

        var packetDataLength = BitConverter.ToInt32(lengthBytes);
        var packetData = new byte[packetDataLength];
        var packetDataRead = await stream.ReadAsync(packetData, token);

        if (packetDataRead != packetDataLength)
        {
            throw new NegumException("Cannot read Packet data.");
        }
        
        return NegumGameContainer.Resolve<IPacketSerializer>().Deserialize(packetData);
    }

    public async Task WriteAsync(Stream stream, IPacket packet, CancellationToken token = default)
    {
        var packetData = NegumGameContainer.Resolve<IPacketSerializer>().Serialize(packet);
        var lengthBytes = BitConverter.GetBytes(packetData.Length);
        var packetDataWithLength = new byte[packetData.Length + lengthBytes.Length];
        
        Array.Copy(lengthBytes, packetDataWithLength, lengthBytes.Length);
        Array.Copy(packetData, 0, packetDataWithLength, lengthBytes.Length, packetData.Length);
        
        await stream.WriteAsync(packetDataWithLength, token);
    }
}