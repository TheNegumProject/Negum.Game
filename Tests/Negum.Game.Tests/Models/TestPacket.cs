using System.IO;
using Negum.Game.Common.Networking.Packets;

namespace Negum.Game.Tests.Models;

public class TestPacket : AbstractPacket
{
    public TestPacket() // Required for deserialization
    {
        SampleString = string.Empty;
    }

    public TestPacket(string sampleString, int sampleInt, double sampleDouble)
    {
        SampleString = sampleString;
        SampleInt = sampleInt;
        SampleDouble = sampleDouble;
    }

    public string SampleString { get; private set; }
    public int SampleInt { get; private set; }
    public double SampleDouble { get; private set; }
    
    public override void Read(BinaryReader reader)
    {
        SampleString = reader.ReadString();
        SampleInt = reader.ReadInt32();
        SampleDouble = reader.ReadDouble();
    }

    public override void Write(BinaryWriter writer)
    {
        writer.Write(SampleString);
        writer.Write(SampleInt);
        writer.Write(SampleDouble);
    }
}