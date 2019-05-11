using System;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.IO;

using MiniAspNet.V2_1;

namespace MiniAspNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string uri = "http://localhost:5000/";
            await new MyHttpServer(uri)
                .StartAsync(FooHandler);
        }

        static async Task FooHandler(HttpContext ctx)
        {
            var html = await Task.Run(() =>
                File.ReadAllBytes("index.html"));
            var task = ctx.Response.Body.WriteAsync(html);
            await task;
        }
    }
}
