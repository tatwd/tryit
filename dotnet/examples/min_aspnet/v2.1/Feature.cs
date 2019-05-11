using System;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace MiniAspNet.V2_1
{
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }

    public interface IHttpResponseFeature
    {
        int StatusCode { get; set; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }

    public class HttpListenerFeature : IHttpRequestFeature, IHttpResponseFeature
    {
        private readonly HttpListenerContext _context;

        public HttpListenerFeature(HttpListenerContext context)
        {
            _context = context;
        }

        Uri IHttpRequestFeature.Url => _context.Request.Url;
        Stream IHttpRequestFeature.Body => _context.Request.InputStream;
        Stream IHttpResponseFeature.Body => _context.Response.OutputStream;
        NameValueCollection IHttpRequestFeature.Headers => _context.Request.Headers;
        NameValueCollection IHttpResponseFeature.Headers => _context.Response.Headers;
        int IHttpResponseFeature.StatusCode
        {
            get { return _context.Response.StatusCode; }
            set { _context.Response.StatusCode = value; }
        }
    }
}