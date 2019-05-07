using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Data;
using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace AppFacturadorApi
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

            //Inyecciones Service
            services.AddTransient<IService<TbDocumento>, TbDocumentoService>();
            services.AddTransient<IService<TbDetalleDocumento>, TbDetalleDocumentoService>();
            services.AddTransient<IService<TbAbonos>, TbAbonosService>();
            services.AddTransient<IService<TbPersona>, TbPersonaService>();
            // Inyecciones Data
            services.AddTransient<IData<TbDocumento>, TbDocumentoData>();
            services.AddTransient<IData<TbDetalleDocumento>, TbDetalleDocumentoData>();
            services.AddTransient<IData<TbAbonos>, TbAbonosData>();
            services.AddTransient<IData<TbPersona>, TbPersonaData>();



            services.AddDbContext<dbSISSODINAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppFacturadorApiConnection")));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)

                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });
         
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseStatusCodePages();
            app.UseMvc();

        }
    }
}
