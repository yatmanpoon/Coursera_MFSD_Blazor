using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EaseEventApp;
using EaseEventApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    Timeout = TimeSpan.FromSeconds(30)
});

// Register services with interfaces for dependency injection
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IAttendanceService>(sp => 
    new AttendanceService(sp.GetRequiredService<IEventService>()));

// Configure recommended WebAssembly settings
builder.Services.AddTransient<HttpClientHandler>(sp =>
{
    var handler = new HttpClientHandler();
    return handler;
});

var host = builder.Build();
await host.RunAsync();
