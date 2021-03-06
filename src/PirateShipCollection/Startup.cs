using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PirateShipCollection.Filters;
using PirateShipCollection.Logic;
using PirateShipCollection.Repositories;
using DbContext = PirateShipCollection.Repositories.DbContext;

namespace PirateShipCollection
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        private readonly IWebHostEnvironment _hostingEnv;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration, ILogger<Startup> logger)
        {
            _hostingEnv = env;
            Configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc(options =>
                {
                    options.InputFormatters
                        .RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                    options.OutputFormatters
                        .RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                })
                .AddXmlSerializerFormatters();


            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Version = "1.0.0",
                        Title = "Swashbuckling Buccaneer Pirate Store",
                        Description = "Swashbuckling Buccaneer Pirate Store",
                    });
                    c.CustomSchemaIds(type => type.FullName);
                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/v2");

                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            services.AddTransient<IShipRepository, ShipRepository>();
            services.AddTransient<IShipLogic, ShipLogic>();
            services.AddTransient<IDevLogic, DevLogic>();

            services.AddScoped<DbContext, DbContext>();

            try
            {
                services.AddDbContext<DbContext>(opt =>
                {
                    var server = Configuration["DbServer"] ?? "localhost";
                    var port = Configuration["DbPort"] ?? "1433";
                    var user = Configuration["DbUser"] ?? "sa";
                    var password = Configuration["Password"] ?? "pass@word1";
                    var database = Configuration["Database"] ?? "shipDb";

                    opt.UseSqlServer(
                        $"Server={server}, {port};Initial Catalog={database};User={user};Password={password}");
                    _logger.LogInformation("Successfully added DB Context");
                });
            }
            catch (Exception e)
            {
                throw new Exception("Adding DB Context failed", e);
            }
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/ErrorDev");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Swashbuckling Buccaneer Pirate Store");
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            _logger.LogInformation("Startup Configure done");
        }
    }
}