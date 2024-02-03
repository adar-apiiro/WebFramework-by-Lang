using ServiceStack;
using System;

namespace ServiceStackDemo
{
    public class HelloRequest : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    public class HelloService : Service
    {
        public object Any(HelloRequest request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }

    public class AppHost : AppSelfHostBase
    {
        public AppHost() : base("ServiceStackDemo", typeof(HelloService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            // Configure your application
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = "http://localhost:5001/";
            var appHost = new AppHost()
                .Init()
                .Start(listeningOn);

            Console.WriteLine($"ServiceStack API running at {listeningOn} ");
            Console.ReadLine();
        }
    }
}