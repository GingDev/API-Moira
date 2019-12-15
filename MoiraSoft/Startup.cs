using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using MoiraSoftDatos.IRepository;
using MoiraSoftDatos.Repository;
using MoiraSoftNegocio;
using MoiraSoftNegocio.BusinessImplementation;
using MoiraSoftNegocio.BusinessInterfaces;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace MoiraSoft
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
            // Obtiene credenciales de config server y se registra en service discovery
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            //services.AddHealthChecksUI();
            DependencyInjection(services);
            AddSwaggerExplorer(services);
            ConfigurationApp(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    options.RoutePrefix = string.Empty;
                });
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseHealthChecks("/healthz", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            //app.UseHealthChecksUI(setup => { setup.ApiPath = "/health"; setup.UIPath = "/healthcheckui"; });

            // Se registra ante Eureka Service Discovery
            // app.UseDiscoveryClient();
        }

        public void ConfigurationApp(IServiceCollection services)
        {
            services.Configure<ConnectionStringOption>(options =>
            {
                options.ConnectionString = Configuration["ConnectionString"];
            });


            DependencyResolver.ServiceProvider = services.BuildServiceProvider();
        }

        public void DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<ILoginSvc, LoginImplSvc>();
            services.AddSingleton<ILoginRepository, LoginRepository>();
            services.AddSingleton<IPersonaSvc, PersonaImplSvc>();
            services.AddSingleton<IPersonaRepository, PersonaRepository>();
            services.AddSingleton<ITurnoSvc, TurnoImplSvc>();
            services.AddSingleton<ITurnoRepository, TurnoRepository>();
        }

        #region [Methods Swagger]
        /// <summary>
        /// Metodo que agrega los servicios de swagger para utilizarlo en el proyecto
        /// </summary>
        /// <param name="services"></param>
        public void AddSwaggerExplorer(IServiceCollection services)
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
                options.OperationFilter<SwaggerDefaultValues>();
                options.IncludeXmlComments(Path.Combine(basePath, fileName));
            });
            services.AddVersionedApiExplorer(
               options =>
               {
                   options.GroupNameFormat = "'v'VVV";
                   options.SubstituteApiVersionInUrl = true;
               });
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });
        }
        /// <summary>
        /// Metodo que obtiene informacion de la api
        /// </summary>
        /// <param name="description">Objeto que contiene datos de la version de la api</param>
        /// <returns></returns>
        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"API MoiraSoft {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "API encargada de administrar las funcionalidades de MoiraSoft",
                Contact = new Contact
                {
                    Name = "KingdomDevelop",
                    Email = "luis.llaulen@gmail.com"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta versión de la API está deprecada.";
            }

            return info;
        }
        #endregion
    }
}
