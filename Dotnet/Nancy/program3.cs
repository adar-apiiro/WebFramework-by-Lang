using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class MainModule : NancyModule
{
    public MainModule()
    {
        // Define a route for handling POST requests to "/greet"
        Post("/greet", args => 
        {
            // Bind the JSON data from the request body to a Person object
            var person = this.Bind<Person>();

            // Create a greeting response
            var greeting = $"Hello, {person.FirstName} {person.LastName}!";

            // Return a JSON response with the greeting
            return new JsonResponse(greeting, new DefaultJsonSerializer());
        });
    }
}

class Program
{
    static void Main()
    {
        // Create and start the NancyHost
        var host = new NancyHost(new Uri("http://localhost:5000"));
        host.Start();

        Console.WriteLine("NancyFX API Server is running. Press Enter to exit.");
        Console.ReadLine();

        // Stop the host when the user presses Enter
        host.Stop();
    }
}
