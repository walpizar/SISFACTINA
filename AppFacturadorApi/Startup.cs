using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFacturadorApi.Data;
using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Seguridad;
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
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            //Inyecciones Service
            services.AddTransient<IService<TbDocumento>, TbDocumentoService>();
            services.AddTransient<IService<TbDetalleDocumento>, TbDetalleDocumentoService>();
            services.AddTransient<IService<TbAbonos>, TbAbonosService>();
            services.AddTransient<IService<TbPersona>, TbPersonaService>();
            services.AddTransient<IService<TbRoles>, TbRolesService>();

            // Inyecciones Data
            services.AddTransient<IData<TbDocumento>, TbDocumentoData>();
            services.AddTransient<IData<TbDetalleDocumento>, TbDetalleDocumentoData>();
            services.AddTransient<IData<TbAbonos>, TbAbonosData>();
            services.AddTransient<IData<TbPersona>, TbPersonaData>();
            services.AddTransient<IData<TbRoles>, TbRolesData>();

            services.AddDbContext<dbSISSODINAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppFacturadorApiConnection")));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)

                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });

            services.AddDefaultIdentity<TbUsuarios>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<dbSISSODINAContext>();

            services.AddCors();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"]).AllowAnyHeader().AllowAnyMethod());
            app.UseStatusCodePages();
            app.UseMvc();

        }
    }
}
