using System.Text;
using Yarp.Telemetry.Consumption;
// using Yarp.ReverseProxy.Transforms;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add the reverse proxy to capability to the server
var proxyBuilder = builder.Services.AddReverseProxy();
// Initialize the reverse proxy from the "ReverseProxy" section of configuration
proxyBuilder.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHttpContextAccessor();

// Interface that collects general metrics about the proxy forwarder
builder.Services.AddSingleton<IForwarderTelemetryConsumer, ForwarderMetricsConsumer>();

// Registration of a consumer to events for proxy forwarder telemetry
builder.Services.AddTelemetryConsumer<ForwarderTelemetryConsumer>();

// Registration of a consumer to events for HttpClient telemetry
// Note: this depends on changes implemented in .NET 5
builder.Services.AddTelemetryConsumer<HttpClientTelemetryConsumer>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Custom middleware that collects and reports the proxy metrics
// Placed at the beginning so it is the first and last thing run for each request
app.UsePerRequestMetricCollection();

app.MapGet("/", () => "Hello World!");

// Enable endpoint routing, required for the reverse proxy
app.UseRouting();
// Register the reverse proxy routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapReverseProxy();
});

app.Run();
