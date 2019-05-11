using System; // Uri
using System.IO; // Stream
using System.Collections.Specialized; // NameValueCollection

namespace MiniAspNet.V2_1
{
    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }

        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
    }

    public class HttpRequest
    {
        private readonly IHttpRequestFeature _httpRequestFeature;

        public HttpRequest(IFeatureCollection features)
        {
            _httpRequestFeature = (IHttpRequestFeature)features[typeof(IHttpRequestFeature)];
        }

        public Uri Url => _httpRequestFeature.Url;
        public NameValueCollection Headers => _httpRequestFeature.Headers;
        public Stream Body => _httpRequestFeature.Body;
    }

    public class HttpResponse
    {
        private readonly IHttpResponseFeature _httpReponseFeature;

        public HttpResponse(IFeatureCollection features)
        {
            _httpReponseFeature = (IHttpResponseFeature)features[typeof(IHttpResponseFeature)];
        }

        public NameValueCollection Headers => _httpReponseFeature.Headers;
        public Stream Body => _httpReponseFeature.Body;
        public int StatusCode
        {
            get { return _httpReponseFeature.StatusCode; }
            set { _httpReponseFeature.StatusCode = value; }
        }
    }
}
