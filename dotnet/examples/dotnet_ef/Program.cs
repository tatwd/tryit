using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef
{
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDbContext())
            {
                TUser m = ctx.TUsers.FirstOrDefault(u => u.Id == 1);
                Console.WriteLine(m?.Name ?? "null");
            }
        }
    }
}