﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.DAL;
using Mono.Services;
using Mono.Services.Common;
using Mono.VehicleRepository.Common;
using Mono.Common;

namespace Mono.MVC
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
            var connection = Configuration.GetSection("MonoDBConnectionString").Get<DataBaseConfiguration>();
            services.AddDbContext<VehicleDBContext>
                (options => options.UseSqlServer(connection.ConnectionString));
            services.AddMvc();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleModelService, VehicleModelService>();
            services.AddTransient<IVehicleModelRepository, Mono.VehicleRepository.VehicleModelRepository>();
            services.AddTransient<IVehicleRepository, Mono.VehicleRepository.VehicleRepository>();
            services.AddTransient<IGenericRepository, Mono.VehicleRepository.GenericRepository>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "home",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
