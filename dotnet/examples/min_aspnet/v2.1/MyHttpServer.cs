using System;
using System.Net;
using System.Threading.Tasks;

namespace MiniAspNet.V2_1
{
    public interface IServer
    {
        Task StartAsync(RequestDelegate handler);
    }

    public class MyHttpServer : IServer
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
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection();
                features.Add(typeof(IHttpRequestFeature), feature);
                features.Add(typeof(IHttpResponseFeature), feature);
                var httpContext = new HttpContext(features);
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }

}
