using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PassportContext>(options =>
                options.UseSqlite("Data Source = PassportIndex.db"));

            services.AddScoped<IPassportInfoRepository, PassportInfoRepository>();
            services.AddScoped<IPassportInfoService, PassportInfoService>();
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();



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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
