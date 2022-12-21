using System.IO;

namespace Negum.Game.Common.Networking.Packets;

/// <summary>
/// Provides a convenient way of reading / writing Packets.
/// </summary>
public abstract class AbstractPacket : IPacket
{
    public AbstractPacket() // Required for deserialization
    {
    }
    
    public virtual void Read(Stream stream) => 
        Read(new BinaryReader(stream));

    public virtual void Write(Stream stream) => 
        Write(new BinaryWriter(stream));

    /// <summary>
    /// Overrides default Read method providing BinaryReader for easier Stream manipulation.
    /// </summary>
    /// <param name="reader"></param>
    public abstract void Read(BinaryReader reader);
        
    /// <summary>
    /// Overrides default Write method providing BinaryWriter for easier Stream manipulation.
    /// </summary>
    /// <param name="writer"></param>
    public abstract void Write(BinaryWriter writer);
}