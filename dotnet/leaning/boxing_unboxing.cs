public class boxing_unboxing
{
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