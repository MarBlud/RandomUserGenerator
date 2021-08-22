using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RandomUserGenerator.Helpers;
using RandomUserGenerator.Logic;
using RandomUserGenerator.Logic.Interfaces;
using RandomUserGenerator.Repositories;
using RandomUserGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomUserGenerator
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
            services.AddControllers();

            RegisterLogicDependencies(services);
            RegisterRepositoryDependencies(services);
            RegisterHelperDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void  RegisterLogicDependencies(IServiceCollection services)
        {
            services.AddSingleton<IRandomUserLogic, RandomUserLogic>();
        }

        private void RegisterRepositoryDependencies(IServiceCollection services)
        {
            services.AddSingleton<IRandomUserRepository, RandomUserRepository>();
        }

        private void RegisterHelperDependencies(IServiceCollection services)
        {
            services.AddSingleton<IUserGeneratorHelper, UserGeneratorHelper>();
        }
    }
}
