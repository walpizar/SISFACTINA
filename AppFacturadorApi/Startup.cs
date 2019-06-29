using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFacturadorApi.Data;
using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.FacturaElectronica.ClasesDatos;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            services.AddTransient<IService<TbAbonos>, AbonosService>();
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
            services.AddTransient<IService<TbCategoriaProducto>, CategoriaProductoService>();
            services.AddTransient<IService<TbImpuestos>, ImpuestosService>();
            services.AddTransient<IService<TbRoles>, RolesService>();
            services.AddTransient<IService<TbPersonasTribunalS>,PersonaTribunalService>();
            services.AddTransient<IService<TbTipoMedidas>, TipoMedidaService>();
            services.AddTransient<IService<TbExoneraciones>, IdExonercionService >();
            services.AddTransient<IService<TbTipoClientes>, TipoClientesService>();
            services.AddTransient<IService<TbSucursales>, SucursalesService>();

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
            services.AddTransient<IData<TbCategoriaProducto>, CategoriaProductoData>();
            services.AddTransient<IData<TbRoles>, RolesData>();
            services.AddTransient<IData<TbImpuestos>, ImpuestosData>();
            services.AddTransient<IData<TbPersonasTribunalS>, PersonaTribunalData>();
            services.AddTransient<IData<TbTipoMedidas>, TipoMedidaData>();
            services.AddTransient<IData<TbExoneraciones>, IdExonercionData>();
            services.AddTransient<IData<TbTipoClientes >,TipoClientesData>();
            services.AddTransient<IData<TbSucursales>, SucursalesData>();

            services.AddDbContext<dbSISSODINAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppFacturadorApiConnection")));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)

                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });
            
            services.AddDefaultIdentity<TbUsuarios>()
             .AddEntityFrameworkStores<dbSISSODINAContext>();
            //Desactivamos o editamos las restricciones de datos.
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;


            });
            //Libreria JWT y Token, (Seguridad)
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
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
            //app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            //app.UseStatusCodePages();
            //app.UseMvc();
            app.UseCors(builder => builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"]).AllowAnyHeader().AllowAnyMethod());
            app.UseStatusCodePages();
            app.UseMvc();

        }
    }
}
