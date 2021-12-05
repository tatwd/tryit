/*
 * 扩展 ReadonlySpan 类
 * 添加 ParseToInt 方法
 */
public static class ReadonlySpanExtension
{
    public static int ParseToInt(this System.ReadOnlySpan<char> rspan)
    {
        System.Int16 sign = 1;
        int num = 0;
        System.UInt16 index = 0;
        if (rspan[0].Equals('-'))
        {
            sign = -1;
            index = 1;
        }
        for (int idx = index; idx < rspan.Length; idx++)
        {
            char c = rspan[idx];
            num = (c - '0') + num * 10;
        }
        return num * sign;
    }

}

public class ref_span
{
    static ref int get_array_ref(int[] arr, int index) => ref arr[index];

    static void try_ref()
    {
        int a = 1;
        ref int b = ref a;
        b++;
        utils.print($"a: {a} b: {b}");

        int[] arr = { 1, 2, 3 };
        ref int n = ref get_array_ref(arr, 1);
        n++;
        utils.print($"arr[1]: {arr[1]} n: {n}");
    }

    static void toint1()
    {
        string s = "content-length:123";
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 0; i < 100000; i++)
            int.Parse(s.Substring(15));
        watch.Stop();
        utils.print("String Substring Convert:\n\tTime Elapsed: {0}ms",
            watch.ElapsedMilliseconds.ToString("N0"));
    }

    // using ReadOnlySpan
    static void toint2()
    {
        string s = "content-length:123";
        var watch = new System.Diagnostics.Stopwatch();
        System.ReadOnlySpan<char> span = s.ToCharArray();
        watch.Start();
        for (int i = 0; i < 100000; i++)
            span.Slice(15).ParseToInt();
        watch.Stop();
        utils.print("ReadOnlySpan Convert:\n\tTime Elapsed: {0}ms",
            watch.ElapsedMilliseconds.ToString("N0"));
    }

    static void try_span()
    {
        toint1();
        toint2();
    }

    [Xunit.Fact]
    public static void run()
    {
        try_ref();
        try_span();
    }
}