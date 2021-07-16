using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.BL.BLInterfaces;
using Airlines.BL.BusnessLogic;
using Airlines.DL.DBcontext;
using Airlines.DL.Interfaces;
using Airlines.DL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Airlines.API
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
            services.AddDbContext<AirlinesDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString"),
                b => b.MigrationsAssembly("Airlines.DL")));

            services.AddControllers();

            services.AddTransient<ILogin,LoginRepository>();
            services.AddTransient<ILoginBL, LoginBusinessLogic>();
            services.AddTransient<IAirlineBL, AirlineBusinessLogic>();
            services.AddTransient<IAirlines, AirlineRepository>();
            services.AddTransient<IFlight, FlightRepository>();
            services.AddTransient<IFlightBL, FlightBusinessLogic>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Airlines API",
                    Version = "v2",
                    Description = "Flight Application",
                });
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Airline Services"));
        }
    }
}
