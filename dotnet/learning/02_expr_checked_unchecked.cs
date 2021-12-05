public class expr_checked_unchecked
{
    [Xunit.Fact]
    public static void run()
    {
        int i = int.MaxValue;
        unchecked
        {
            System.Console.WriteLine(i + 1); // overflow
        }
        checked
        {
            System.Console.WriteLine(i + 1); // exception
        }
    }
}