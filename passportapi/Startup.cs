using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using passportapi.Domain.Models;
using passportapi.Domain.Repository;
using passportapi.Domain.Services;
using passportapi.Persistance.Contexts;
using passportapi.Persistance.Repositories;
using passportapi.Services;

namespace passportapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //configure database
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("dataset")));

            services.AddScoped<IPassportInfoRepository, PassportInfoRepository>();
            services.AddScoped<IPassportInfoService, PassportInfoService>();
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");

                routes.MapRoute(
                    name: "twoCountries",
                    template: "{controller}/{action}/{source}/{destination}");
            });
        }
    }
}
