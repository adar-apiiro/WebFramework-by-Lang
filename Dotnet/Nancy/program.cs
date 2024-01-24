using Nancy;
using Nancy.Configuration;
using Nancy.Hosting.Self;

public class CustomBootstrapper : DefaultNancyBootstrapper
{
    public override void Configure(INancyEnvironment environment)
    {
        // You can configure the environment if needed
        base.Configure(environment);
    }
}

public class SampleModule : NancyModule
{
    public SampleModule()
    {
        Get("/", args => "Hello, NancyFX!");
        
        // Define your API routes and handlers here
        Get("/api/data", args => {
            var data = new { Message = "API Data", Value = 42 };
            return Response.AsJson(data);
        });
    }
}

class Program
{
    static void Main(string[] args)
    {
        var configuration = new HostConfiguration
        {
            UrlReservations = new UrlReservations { CreateAutomatically = true }
        };

        using (var host = new NancyHost(new CustomBootstrapper(), configuration, new Uri("http://localhost:1234")))
        {
            host.Start();
            Console.WriteLine("NancyFX API Server is running on http://localhost:1234");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
