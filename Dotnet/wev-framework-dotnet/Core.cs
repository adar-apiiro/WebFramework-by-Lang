using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspNetCoreDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

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
            });
        }
    }

    public class GreetingController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("/api/greeting")]
        public IActionResult GetGreeting()
        {
            return Ok("Hello from ASP.NET Core!");
        }

        [HttpPut("/api/update")]
        public IActionResult UpdateResource()
        {
            // Simulate updating a resource
            return Ok("Resource updated");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://localhost:5002");
                })
                .Build()
                .Run();
        }
    }
}