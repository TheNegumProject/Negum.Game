using System.IO;
using System.Threading.Tasks;
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
    /// <returns></returns>
    Task<IPacket> ReadAsync(Stream stream);
    
    /// <summary>
    /// Writes Packet into Stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="packet"></param>
    /// <returns></returns>
    Task WriteAsync(Stream stream, IPacket packet);
}

public class NetworkPacketSerializer : INetworkPacketSerializer
{
    public async Task<IPacket> ReadAsync(Stream stream)
    {
        var reader = new BinaryReader(stream);
        var packetDataLength = reader.ReadInt32();
        var packetData = new byte[packetDataLength];
        
        var bytesRead = await stream.ReadAsync(packetData);

        return bytesRead == 0 
            ? new EmptyPacket() 
            : NegumGameContainer.Resolve<IPacketSerializer>().Deserialize(packetData);
    }

    public async Task WriteAsync(Stream stream, IPacket packet)
    {
        var packetData = NegumGameContainer.Resolve<IPacketSerializer>().Serialize(packet);

        var writer = new BinaryWriter(stream);
        writer.Write(packetData.Length);

        await stream.WriteAsync(packetData);
    }
}