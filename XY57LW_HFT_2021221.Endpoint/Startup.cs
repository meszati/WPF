using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Logic;
using XY57LW_HFT_2021221.Repository;
using XY57LW_HFT_2021221.Data;
using XY57LW_HFT_2021221.Endpoint.Services;

namespace XY57LW_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ISchoolLogic, SchoolLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IMeasurementLogic, MeasurementLogic>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IMeasurementRepository, MeasurementRepository>();
            services.AddTransient<StudentNetfitDbContext, StudentNetfitDbContext>();

            services.AddSignalR();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
