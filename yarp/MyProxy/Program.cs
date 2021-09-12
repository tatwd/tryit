using System.Text;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

// Add the reverse proxy to capability to the server
var proxyBuilder = builder.Services.AddReverseProxy();
// Initialize the reverse proxy from the "ReverseProxy" section of configuration
proxyBuilder.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");
// app.MapGet("/bar/{**all}",  (ctx) => {
//     var sb = new StringBuilder();

//     sb.AppendFormat("path: {0}\n", ctx.Request.Path);
//     sb.AppendFormat("query: {0}\n", ctx.Request.QueryString);
//     sb.AppendLine("headers: ");
//     foreach (var (k, v) in ctx.Request.Headers) {
//         sb.AppendFormat("   {0}: {1}\n", k, v);
//     }
//     return ctx.Response.WriteAsync(sb.ToString());
// });


// Enable endpoint routing, required for the reverse proxy
app.UseRouting();
// Register the reverse proxy routes
app.UseEndpoints(endpoints => 
{
    endpoints.MapReverseProxy(); 
}); 

app.Run();
