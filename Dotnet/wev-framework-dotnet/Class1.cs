using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;

namespace NancyDemo
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            // Custom application startup configuration
        }
    }

    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get("/api/greeting", _ => "Hello from NancyFX!");

            Put("/api/update", _ =>
            {
                // Simulate updating a resource
                return "Resource updated";
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true }
            };

            using (var host = new NancyHost(new CustomBootstrapper(), config, new Uri("http://localhost:5000")))
            {
                host.Start();
                Console.WriteLine("NancyFX server running on http://localhost:5000");
                Console.ReadLine();
            }
        }
    }
}