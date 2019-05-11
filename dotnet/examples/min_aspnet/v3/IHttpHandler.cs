using System;
using System.Threading.Tasks;

namespace MiniAspNet.V3
{
    public delegate Task RequestDelegate(HttpContext context);
}
