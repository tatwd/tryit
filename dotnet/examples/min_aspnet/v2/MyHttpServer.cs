using System;
using System.Net;
using System.Threading.Tasks;

namespace MiniAspNet.V2
{
    public class MyHttpServer
    {
        private readonly HttpListener _listener;
        private readonly string _uri;

        public MyHttpServer(string uri)
        {
            _listener = new HttpListener();
            _uri = uri;
        }

        public async Task StartAsync(RequestDelegate handler)
        {
            _listener.Prefixes.Add(_uri);
            _listener.Start();
            Console.WriteLine($"Start '{typeof(MyHttpServer).Name}' and listen on {_uri}");
            while (true)
            {
                var listenerContext = await _listener.GetContextAsync();
                var httpContext = new HttpContext
                {
                    Request = new HttpRequest{
                        Url = listenerContext.Request.Url,
                        Headers = listenerContext.Request.Headers,
                        Body = listenerContext.Request.InputStream
                    },
                    Response = new HttpResponse{
                        Headers = listenerContext.Response.Headers,
                        Body = listenerContext.Response.OutputStream,
                        StatusCode = listenerContext.Response.StatusCode
                    }
                };
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }

}
