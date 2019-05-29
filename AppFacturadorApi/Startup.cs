using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Data;
using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.FacturaElectronica.ClasesDatos;
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
            services.AddTransient<IService<TbDocumento>, DocumentoService>();
            services.AddTransient<IService<TbDetalleDocumento>, DetalleDocumentoService>();
            services.AddTransient<IService<TbAbonos>, TbAbonosService>();
            services.AddTransient<IService<TbPersona>, PersonaService>();
            services.AddTransient<IService<TbProducto>, ProductoService>();
            services.AddTransient<IService<TbClientes>, ClientesService>();
            services.AddTransient<IService<TbTipoVenta>, TipoVentaService>();
            services.AddTransient<IService<TbTipoPago>, TipoPagoService>();
            services.AddTransient<IService<TbTipoId>, TipoIdService>();
            services.AddTransient<IService<TbInventario>, InventarioService>();
            services.AddTransient<IService<TbEmpresa>, EmpresaService>();
            services.AddTransient<IService<TbProvincia>, ProvinciaService>();
            services.AddTransient<IService<TbCanton>, CantonService>();
            services.AddTransient<IService<TbDistrito>, DistritoService>();
            services.AddTransient<IService<TbBarrios>, BarrioService>();
            services.AddTransient<IService<TbProveedores>, TbProveedorService>();
            services.AddTransient<IService<TbParametrosEmpresa>, ParametrosEmpresaService>();

            // Inyecciones Data
            services.AddTransient<Datos>();
            services.AddTransient<IData<TbDocumento>, DocumentoData>();
            services.AddTransient<IData<TbDetalleDocumento>, DetalleDocumentoData>();
            services.AddTransient<IData<TbAbonos>, AbonosData>();
            services.AddTransient<IData<TbPersona>, PersonaData>();
            services.AddTransient<IData<TbProducto>, ProductoData>();
            services.AddTransient<IData<TbClientes>, ClientesData>();
            services.AddTransient<IData<TbTipoVenta>, TipoVentaData>();
            services.AddTransient<IData<TbTipoPago>, TipoPagoData>();
            services.AddTransient<IData<TbTipoId>, TipoIdData>();
            services.AddTransient<IData<TbInventario>, InventarioData>();
            services.AddTransient<IData<TbEmpresa>, EmpresaData>();
            services.AddTransient<IData<TbProvincia>, ProvinciaData>();
            services.AddTransient<IData<TbCanton>, CantonData>();
            services.AddTransient<IData<TbDistrito>, DistritoData>();
            services.AddTransient<IData<TbBarrios>, BarrioData>();
            services.AddTransient<IData<TbProveedores>, ProveedorData>();
            services.AddTransient<IData<TbParametrosEmpresa>, ParametrosEmpresaData>();


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
