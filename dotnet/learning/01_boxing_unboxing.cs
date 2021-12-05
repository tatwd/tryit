/*
 * 装箱：值类型转引用类型
 * 拆箱：引用类型转值类型
 */
public class boxing_unboxing
{
    [Xunit.Fact]
    public static void run()
    {
        int n = 1;
        object o = n; // boxing
        int i = (int) o; // unboxing

        System.Console.WriteLine($"n: {n}");
        System.Console.WriteLine($"o: {n}");
        System.Console.WriteLine($"i: {n}");
    }
}