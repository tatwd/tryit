public class expr_yield
{
    public System.Collections.Generic.IEnumerable<int> range(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            yield return i;
        }
        yield break;
    }

    public static void run()
    {
        var expr = new expr_yield();
        foreach (var item in expr.range(-10, 10))
        {
            System.Console.WriteLine(item);
        }
    }
}