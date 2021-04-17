using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Game.Client;
using Negum.Game.Common.Containers;
using Xunit;

namespace Negum.Game.Tests.Factories
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class NegumClientFactoryTests
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main")]
        public async Task Should_Create_New_Negum_Client_Object(string negumDirPath)
        {
            NegumContainer.RegisterKnownTypes();
            NegumGameContainer.RegisterKnownTypes();

            var client = await NegumClientFactory.CreateAsync(negumDirPath);

            Assert.NotNull(client);
        }
    }
}