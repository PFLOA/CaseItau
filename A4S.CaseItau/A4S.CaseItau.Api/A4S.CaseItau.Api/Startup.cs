using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using A4S.CaseItau.Infra.Data;
using A4S.CaseItau.Injection;
using System.Reflection;
using Prometheus;
using System.IO;
using Serilog;
using MediatR;
using System;

namespace A4S.CaseItau.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CaseItauTwitterContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();
            services.AddLogging(logger => logger.AddSerilog());
            services.AddServices();

            services.AddMediatR(typeof(Application.Handlers.Postagens.Handler.BuscarPostagensPorHoraDiaHandler).GetTypeInfo().Assembly);

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Case Itau Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.EnableAnnotations();
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMetricServer();
            app.UseHttpMetrics();

            app.UseAuthorization();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Case Itau Api");
                c.RoutePrefix = string.Empty;
                c.EnableFilter();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
        }
    }
}
