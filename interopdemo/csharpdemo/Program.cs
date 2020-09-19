using System;
using System.Runtime.InteropServices;

namespace csharpdemo
{
    public static class MyLib
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
            try
            {
                var sum = MyLib.Add(1, 2);
                Console.WriteLine(sum);

                const string s = "Hello World!\n";
                var ret = MyLib.Hello(s.ToCharArray(), s.Length);
                Console.WriteLine(ret);
                ret = MyLib.Hello(null, s.Length);
                Console.WriteLine(ret);
                ret = MyLib.Hello(s.ToCharArray(), 0);
                Console.WriteLine(ret);

                const string str = "你好!\n";
                ret = MyLib.Say(str);
                Console.WriteLine(ret);
                ret = MyLib.Say(null);
                Console.WriteLine(ret);
                ret = MyLib.Say("");
                Console.WriteLine(ret);
            }
            catch (DllNotFoundException ex)
            {
                Console.WriteLine("先到 clibdemo 编译动态链接库 libmy.so => make");
                Console.WriteLine(ex.Message);
            }
        }
    }
}