using System;
using System.Threading.Tasks;

namespace MiniAspNet.V2_1
{
    public delegate Task RequestDelegate(HttpContext context);
}
