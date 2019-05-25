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
            services.AddTransient<IService<TbProducto>, TbProductoService>();
            services.AddTransient<IService<TbClientes>, ClientesService>();
            services.AddTransient<IService<TbTipoVenta>, TipoVentaService>();
            services.AddTransient<IService<TbTipoPago>, TipoPagoService>();
            services.AddTransient<IService<TbTipoId>, TipoIdService>();
            services.AddTransient<IService<TbInventario>, InventarioService>();
            services.AddTransient<IService<TbEmpresa>, EmpresaService>();
            services.AddTransient<IService<TbProvincia>, TbProvinciaService>();
            services.AddTransient<IService<TbCanton>, TbCantonService>();
            services.AddTransient<IService<TbDistrito>, TbDistritoService>();
            services.AddTransient<IService<TbBarrios>, TbBarrioService>();

            // Inyecciones Data
            services.AddTransient<IData<TbDocumento>, TbDocumentoData>();
            services.AddTransient<IData<TbDetalleDocumento>, TbDetalleDocumentoData>();
            services.AddTransient<IData<TbAbonos>, TbAbonosData>();
            services.AddTransient<IData<TbPersona>, TbPersonaData>();
            services.AddTransient<IData<TbProducto>, TbProductoData>();
            services.AddTransient<IData<TbClientes>, ClientesData>();
            services.AddTransient<IData<TbTipoVenta>, TipoVentaData>();
            services.AddTransient<IData<TbTipoPago>, TipoPagoData>();
            services.AddTransient<IData<TbTipoId>, TipoIdData>();
            services.AddTransient<IData<TbInventario>, InventarioData>();
            services.AddTransient<IData<TbEmpresa>, EmpresaData>();
            services.AddTransient<IData<TbProvincia>, TbProvinciaData>();
            services.AddTransient<IData<TbCanton>, TbCantonData>();
            services.AddTransient<IData<TbDistrito>, TbDistritoData>();
            services.AddTransient<IData<TbBarrios>, TbBarrioData>();


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
