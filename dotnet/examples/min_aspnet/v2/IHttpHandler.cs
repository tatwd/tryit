using System;
using System.Threading.Tasks;

namespace MiniAspNet.V2
{
    // public interface IHttpHandler
    // {
    //     Task Handle(HttpContext context); // same as Func<HttpContext, Task>
    // }

    public delegate Task RequestDelegate(HttpContext context);
}
