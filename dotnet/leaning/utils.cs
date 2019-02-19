class utils
{
    public static void print(string fmt, params object[] args)
    {
        System.Console.WriteLine(fmt, args);
    }

    public static void print(System.Collections.IEnumerable e)
    {
        var en = e.GetEnumerator();
        System.Console.Write("[");
        if (en.MoveNext())
        {
            System.Console.Write($" {en.Current}");
            while (en.MoveNext())
                System.Console.Write($", {en.Current}");
        }
        System.Console.WriteLine(" ]");
    }

    public static void print(object e)
    {
        var arr = e.GetType().GetProperties();
        var len = arr.Length;
        System.Console.Write("{");
        if (len > 0)
        {
            if (arr[0].CanRead && arr[0].CanWrite)
            {
                System.Console.Write($" {arr[0].Name}: {arr[0].GetValue(e)}");
                for (int i = 1; i < len; i++)
                    if (arr[i].CanRead && arr[i].CanWrite)
                        System.Console.Write($", {arr[i].Name}: {arr[i].GetValue(e)}");
            }
            System.Console.WriteLine(" }");
        }
    }
}