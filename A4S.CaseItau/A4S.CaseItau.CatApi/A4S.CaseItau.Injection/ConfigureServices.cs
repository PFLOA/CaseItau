using Microsoft.Extensions.DependencyInjection;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Infra.Repository;
using A4S.CaseItau.HTTP;

namespace A4S.CaseItau.Injection
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICatApi, CatApi>();
            services.AddScoped<IRacaRepository, RacaRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
        }
    }
}
