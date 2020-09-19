using System;
using System.Runtime.InteropServices;

namespace csharpdemo
{

    public static class MyMath
    {
        [DllImport("my", EntryPoint = "myadd")]
        public static extern int Add(int a, int b);

        [DllImport("my", EntryPoint = "myhello")]
        public static extern int Hello(char[] s, int len);

        [DllImport("my", EntryPoint = "mysay")]
        public static extern int Say(string s);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sum = MyMath.Add(1, 2);
            Console.WriteLine(sum);

            const string s = "Hello World!\n";
            var ret = MyMath.Hello(s.ToCharArray(), s.Length);
            Console.WriteLine(ret);
            ret = MyMath.Hello(null, s.Length);
            Console.WriteLine(ret);
            ret = MyMath.Hello(s.ToCharArray(), 0);
            Console.WriteLine(ret);

            const string str = "你好!\n";
            ret = MyMath.Say(str);
            // Console.WriteLine(ret);
            // ret = MyMath.Say(null);
            // Console.WriteLine(ret);
            // ret = MyMath.Say("");
            // Console.WriteLine(ret);
        }
    }
}