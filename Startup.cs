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
using CurrencyQuotes.Data;
using Microsoft.EntityFrameworkCore;

/*
https://docs.awesomeapi.com.br/api-de-moedas
*/


namespace CurrencyQuotes
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

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddHealthChecks();
            services.AddAuthorization();
            services.AddControllers();            
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            var Server = Environment.GetEnvironmentVariable("Server");
            var Database = Environment.GetEnvironmentVariable("Database");
            var Uid = Environment.GetEnvironmentVariable("Uid");
            var Pwd = Environment.GetEnvironmentVariable("Pwd");

            var mySql = "Server="+Server+";Port=3306;Database="+Database+";Uid="+Uid+";Pwd="+Pwd+";charset=utf8;ConvertZeroDateTime=True;";
                
            services.AddDbContext<DBContext>(options => options.UseMySql(mySql));


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
            
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
