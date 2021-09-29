using Dominion.Test.Infrastructure.Reposiroty.Service;
using Dominion.Test.Services.Interfaces;
using Dominion.Test.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _environment = env;
        }

        public IWebHostEnvironment _environment { get; set; }
        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (isDevelopment())
            {
                var dbServer = _configuration.GetSection("ConnectionServer")["Local"];
                if (string.IsNullOrEmpty(dbServer))
                {
                    dbServer = _configuration.GetSection("ConnectionServer")["External"];
                }
                connectionString = string.Format(connectionString, dbServer);
            }
            else
            {
                var dbServer = _configuration.GetSection("ConnectionServer")["External"];
                connectionString = string.Format(connectionString, dbServer);
            }

            services.AddDbContext<DominionContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IResponseService, ResponseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool isDevelopment()
        {
            return _environment.EnvironmentName == "Development";
        }

        private bool isProduction()
        {
            return _environment.EnvironmentName == "Release";
        }

        private bool isTest()
        {
            return _environment.EnvironmentName == "Test";
        }
    }
}
