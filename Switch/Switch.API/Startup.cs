using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Switch.Infra.Data.Context;

namespace Switch.API
{
    public class Startup
    {
        IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            //passa para a configuração o arquivo de configuração
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //passa a string de conexão
            var conn = Configuration.GetConnectionString("SwitchDB");
            //adiciona o contexto
            //passa a configuração do LazyLoading que esta sendo usada
            //informa o tipo de banco de dados que esta sendo usado, no caso MySQL
            //Informa em qual projeto esta o EntityFramework
            services.AddDbContext<SwitchContext>(option => option.UseLazyLoadingProxies().UseMySql(conn, m => m.MigrationsAssembly("Switch.Infra.Data")));
            services.AddMvcCore();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
