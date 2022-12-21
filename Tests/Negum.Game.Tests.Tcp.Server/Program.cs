using Negum.Game.Common.Containers;
using Negum.Game.Common.Networking;

await NegumGameContainer
    .Resolve<IServerListener>()
    .RunAsync();