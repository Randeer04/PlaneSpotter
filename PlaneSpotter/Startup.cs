using Microservices.Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PlaneSpotter.Mapping;
using PlaneSpotter.Repositories;
using PlaneSpotter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter
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
            services.AddDbContext<CommonDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PlaneSpotterConnection"),
            b => b.MigrationsAssembly("PlaneSpotter")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlaneSpotter", Version = "v1" });
            });

            #region Service DI
            services.AddScoped<IGetSightingService, GetSightingService>();
            services.AddScoped<ICreateSightingService, CreateSightingService>();
            services.AddScoped<IEditSightingService, EditSightingService>();
            #endregion

            #region Repository DI
            services.AddScoped<IGetSightingRepository, GetSightingRepository>();
            services.AddScoped<ICreateSightingRepository, CreateSightingRepository>();
            services.AddScoped<IEditSightingRepository, EditSightingRepository>();
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(EntityToViewModelMappingProfile));
            services.AddAutoMapper(typeof(ViewModelToEntityMappingProfile));
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plane Spotter v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
