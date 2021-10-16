using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistencia;
using Dominio;

namespace Presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //Inyeccion de dependencia
            services.AddScoped<IRepositorioMunicipio, RepositorioMunicipio>();
            services.AddScoped<IRepositorioPersona, RepositorioPersona>();
            services.AddScoped<IRepositorioPersona_Equipo, RepositorioPersona_Equipo>();
            services.AddScoped<IRepositorioCancha, RepositorioCancha>();
            services.AddScoped<IRepositorioEncuentro, RepositorioEncuentro>();
            services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            services.AddScoped<IRepositorioEquipos_Torneos, RepositorioEquipos_Torneos>();
            services.AddScoped<IRepositorioEscenario, RepositorioEscenario>();
            services.AddScoped<IRepositorioTorneo, RepositorioTorneo>();
            services.AddScoped<IRepositorioTorneos_Encuentros, RepositorioTorneos_Encuentros>();
            //REgistrar el contexto
            services.AddDbContext<Persistencia.AppContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
