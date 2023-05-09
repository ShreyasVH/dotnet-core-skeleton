using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    services.AddControllers(); // Add controller services to the container
                });
                webBuilder.Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers(); // Map controllers
                    });
                });
                // webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:" + GetPortFromEnvironment());
            });

    private static string GetPortFromEnvironment()
    {
        // Read the environment variable for the port, e.g., "ASPNETCORE_PORT"
        string port = Environment.GetEnvironmentVariable("ASPNETCORE_PORT") ?? "5000";
        return port;
    }
}