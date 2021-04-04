using Negum.Core.Containers;
using Negum.Game.Client;
using Negum.Game.Client.Input;
using Negum.Game.Client.Network;
using Negum.Game.Common.Containers;
using Xunit;

namespace Negum.Game.Tests.Containers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ContainerTests
    {
        [Fact]
        public void Should_Register_All_Client_Modules()
        {
            NegumGameContainer.RegisterKnownTypes();
            
            Assert.NotNull(NegumContainer.Resolve<IClientPacketHandler>());
            Assert.NotNull(NegumContainer.Resolve<IInputManager>());
            Assert.NotNull(NegumContainer.Resolve<IClientHooks>());
        }
    }
}