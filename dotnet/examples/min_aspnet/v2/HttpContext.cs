using System; // Uri
using System.IO; // Stream
using System.Collections.Specialized; // NameValueCollection

namespace MiniAspNet.V2
{
    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }
    }

    public class HttpRequest
    {
        public Uri Url { get; set; }
        public NameValueCollection Headers { get; set; }
        public Stream Body { get; set; }
    }

    public class HttpResponse
    {
        public NameValueCollection Headers { get; set; }
        public Stream Body { get; set; }
        public int StatusCode { get; set; }
    }
}
