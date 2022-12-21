using Negum.Game.Client;
using Negum.Game.Tests.Models;

// Mock running cycle - this should be created in user's code
var source = new CancellationTokenSource();

await NegumClientRunner.RunAsync(
    token: source.Token,
    assembliesWithPacketHandlers: new []
    {
        typeof(TestPacket).Assembly
    }
);