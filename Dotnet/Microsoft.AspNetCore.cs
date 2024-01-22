using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Define a simple data model
record Person(string Name, int Age);

// Configure endpoints
builder.Services.AddEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello, World!");
    });

    endpoints.MapGet("/api/people", async context =>
    {
        var people = new[]
        {
            new Person("Alice", 30),
            new Person("Bob", 25),
            new Person("Charlie", 40)
        };

        await context.Response.WriteAsJsonAsync(people);
    });

    endpoints.MapGet("/api/greet/{name}", async context =>
    {
        var name = context.Request.RouteValues["name"] as string;
        await context.Response.WriteAsync($"Hello, {name}!");
    });
});

var app = builder.Build();

// Configure the app to use JSON and handle exceptions
app.UseJson();
app.UseExceptionHandler("/error");

// Configure the environment
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();
