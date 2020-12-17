using AutoMapper;
using CopaDeFilmes.Application.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CopaDeFilmes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling
                   = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            services.RegisterServices();
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API V1 Title",
                    Description = "API V1 Description"
                });

                //c.SwaggerDoc("v2", new OpenApiInfo
                //{
                //    Version = "v2",
                //    Title = "API V2 Title",
                //    Description = "API V2 Description"
                //});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint($"/swagger/v1/swagger.json", "API V1");
                //opt.SwaggerEndpoint($"/swagger/v2/swagger.json", "API V2");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
