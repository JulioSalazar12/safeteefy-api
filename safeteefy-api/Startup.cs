using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using safeteefy_api.Guardians.Domain.Repositories;
using safeteefy_api.Guardians.Domain.Services;
using safeteefy_api.Guardians.Persistence.Repositories;
using safeteefy_api.Guardians.Services;
using safeteefy_api.Shared.Domain.Repositories;
using safeteefy_api.Shared.Persistence.Context;
using safeteefy_api.Shared.Persistence.Repositories;
using safeteefy_api.Urgencies.Domain.Repositories;
using safeteefy_api.Urgencies.Domain.Services;
using safeteefy_api.Urgencies.Persistence.Repositories;
using safeteefy_api.Urgencies.Services;

namespace safeteefy_api
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

            services.AddRouting(p => p.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "safeteefy_api", Version = "v1"});
            });

            services.AddDbContext<AppDbContext>();

            services.AddScoped<IGuardianRepository, GuardianRepository>();
            
            services.AddScoped<IGuardianService, GuardianService>();
            
            services.AddScoped<IUrgencyRepository, UrgencyRepository>();
            
            services.AddScoped<IUrgencyService, UrgencyService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "safeteefy_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}