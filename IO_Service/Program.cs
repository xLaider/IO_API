using IO_Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsfot", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\Users\Mateusz\source\repos\IO_API\LogFile.txt")
    .CreateLogger();

try
{
    Log.Information("Starting up the service");
    IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    }).UseSerilog()
    .Build();

    await host.RunAsync();

}
catch (Exception ex)
{
    Log.Fatal(ex, "There was a problem startic the service");
    return;
}
finally
{
    Log.CloseAndFlush();
}


