using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAspNet.V3
{
    // 中间件管理
    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        RequestDelegate Build();
    }

    public class ApplicationBuilder : IApplicationBuilder
    {
        private List<Func<RequestDelegate, RequestDelegate>> _middlewares =
            new List<Func<RequestDelegate, RequestDelegate>>();
        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public RequestDelegate Build()
        {
            _middlewares.Reverse();
            RequestDelegate next = (context) => {
                context.Response.StatusCode = 404;
                return Task.CompletedTask;
            };
            foreach (var item in _middlewares)
                next = item(next);
            return next; // now `next` is the first item
        }
    }
}