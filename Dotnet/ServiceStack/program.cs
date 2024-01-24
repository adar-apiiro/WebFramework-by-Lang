using System;
using Funq;
using ServiceStack;
using ServiceStack.Text;

[Route("/hello")]
[Route("/hello/{Name}")]
public class Hello : IReturn<HelloResponse>
{
    public string Name { get; set; }
}

public class HelloResponse
{
    public string Result { get; set; }
}

public class HelloService : Service
{
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}

class Program
{
    static void Main(string[] args)
    {
        var appHost = new AppHost()
            .Init()
            .Start("http://localhost:1234/");

        Console.WriteLine("ServiceStack API Server is running on http://localhost:1234");
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

        appHost.Dispose();
    }
}

public class AppHost : AppSelfHostBase
{
    public AppHost() : base("ServiceStack Example", typeof(HelloService).Assembly) { }

    public override void Configure(Container container)
    {
        // Any additional configuration can be done here
    }
}
