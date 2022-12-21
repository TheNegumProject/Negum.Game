using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;
using Negum.Game.Tests.Models;

// Register testing Assembly
NegumGameContainer.RegisterPacketHandlers(typeof(TestPacket).Assembly);

// Make sure to setup configuration first
NegumGameContainer.Resolve<IServerConfiguration>().ConnectToLocalServer();

// Try start local server
var thread = new Thread(() =>
{
    NegumGameContainer.Resolve<IServerListener>().StartAsync().Wait();
});

thread.Start();

// Try send request to local server
await NegumGameContainer
    .Resolve<INetworkManager>()
    .SendPacketAsync(new TestPacket(
        "Testing Local Server", 
        123, 
        456.789));
       
// Stop local server
await NegumGameContainer.Resolve<IServerListener>().StopAsync();