using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Funq;

// Define your ServiceStack web service request (i.e., Request DTO).
[Route("/contacts", "GET")]
public class GetContacts : IReturn<List<Contact>> { }

// Define the Response DTO
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Create your ServiceStack service implementation.
public class ContactsService : Service
{
    public async Task<object> Get(GetContacts request)
    {
        // Example: Fetch from in-memory list for simplicity
        return new List<Contact> {
            new Contact { Id = 1, Name = "John Doe" },
            new Contact { Id = 2, Name = "Jane Doe" }
        };
    }
}

// Define the ASP.NET Core application's entry point and configure ServiceStack.
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddServiceStack(new AppHost());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseRouting();

        app.UseServiceStack(new AppHost
        {
            AppSettings = new NetCoreAppSettings(builder.Configuration)
        });

        app.Run();
    }
}

// Define your ServiceStack AppHost configuration.
public class AppHost : AppHostBase
{
    public AppHost() : base("My API", typeof(ContactsService).Assembly) { }

    // Configure your AppHost with the necessary ServiceStack configuration
    public override void Configure(Container container)
    {
        // Register any dependencies your services require here
        // For example, to use an in-memory database for development purposes:
        container.Register<IDbConnectionFactory>(c =>
            new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
        
        // Example route registration
        SetConfig(new HostConfig { DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false) });
    }
}
