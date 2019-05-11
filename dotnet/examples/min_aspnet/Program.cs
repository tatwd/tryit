using System;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.IO;

using MiniAspNet.V3;

namespace MiniAspNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string uri = "http://localhost:5000/";
            IServer server = new MyHttpServer(uri);
            var handler = new ApplicationBuilder()
                .Use(FooMiddleware)
                .Use(BarMiddleware)
                .Use(BazMiddleware)
                .Build();
            await server.StartAsync(handler);
        }

        static RequestDelegate FooMiddleware(RequestDelegate next)
        {
            return async context => {
                await context.Response.Body.WriteAsync(
                    Encoding.UTF8.GetBytes("Foo=>"));
                await next(context);
            };
        }

        static RequestDelegate BarMiddleware(RequestDelegate next)
        {
            return async context => {
                await context.Response.Body.WriteAsync(
                    Encoding.UTF8.GetBytes("Bar=>"));
                await next(context);
            };
        }

        static RequestDelegate BazMiddleware(RequestDelegate next)
        {
            return async context => {
                await context.Response.Body.WriteAsync(
                    Encoding.UTF8.GetBytes("Baz"));
                await next(context);
            };
        }
    }
}
