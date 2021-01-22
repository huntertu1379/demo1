using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Service;
using MISA.ApplicationCore.Services;
using MISA.Infrastructure.Reponsitory;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MISA.CukCuk.Api
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
            services.AddCors();
            services.AddControllers()
                        .AddNewtonsoftJson(options =>
                        {
                            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                        });
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped(typeof(IBaseRespository<>), typeof(BaseRespository<>));
            services.AddScoped(typeof(IBaseService<>),typeof(BaseService<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            //Cấu hình html
            app.UseStaticFiles();
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
