using Microsoft.Extensions.Configuration;

namespace A4S.CaseItau.Core.HTTP
{
    public class HttpBase
    {
        protected readonly string _bearer;
        protected readonly string _url;

        public HttpBase(IConfiguration configuration, string section)
        {
            _url = configuration.GetValue<string>($"{section}:BaseUrl");
            _bearer = configuration.GetValue<string>($"{section}:Bearer");
        }
    }
}
