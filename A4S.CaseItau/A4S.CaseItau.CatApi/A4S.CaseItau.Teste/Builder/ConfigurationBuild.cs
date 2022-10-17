using Microsoft.Extensions.Configuration;
using Moq;

namespace A4S.CaseItau.Teste.Builder
{
    public class ConfigurationBuild
    {
        public static Mock<IConfiguration> MockContext()
        {
            var url = new Mock<IConfigurationSection>();
            var bearer = new Mock<IConfigurationSection>();
            var configurationMock = new Mock<IConfiguration>();

            url.Setup(x => x.Value).Returns("https://api.twitter.com/2/");
            configurationMock.Setup(x => x.GetSection("Twitter:BaseUrl")).Returns(url.Object);

            bearer.Setup(x => x.Value).Returns("AAAAAAAAAAAAAAAAAAAAANc6iAEAAAAANlqP8pm52HC94aXBxVSfeb6u9NA%3D98s4VI243gU88rQVvuKcm4NRBHxrneHwqzcuIvPnmv3PWsrldT");
            configurationMock.Setup(x => x.GetSection("Twitter:Bearer")).Returns(bearer.Object);

            return configurationMock;
        }
    }
}
