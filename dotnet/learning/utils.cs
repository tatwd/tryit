class utils
{
    public static void println(string fmt, params object[] args)
    {
        System.Console.WriteLine(fmt, args);
    }

    public static void print(string fmt, params object[] args)
    {
        System.Console.Write(fmt, args);
    }

    public static string print(System.Collections.IEnumerable e)
    {
        var en = e.GetEnumerator();
        var str = new System.Text.StringBuilder("[");
        if (en.MoveNext())
        {
            if (!en.Current.GetType().IsPrimitive) 
            {
                str.Append(print(en.Current, false));
            }
            else 
            {
                str.Append($" {en.Current}");
                while (en.MoveNext())
                    str.Append($", {en.Current}");
            }
        }
        str.Append("]");
        System.Console.WriteLine(str.ToString());
        return str.ToString();
    }

    public static string print(object e, bool is_print = true)
    {
        var arr = e.GetType().GetProperties();
        var len = arr.Length;
        var str = new System.Text.StringBuilder("{");
        if (len > 0)
        {
            if (arr[0].CanRead)
            {
                str.Append($" {arr[0].Name}: {arr[0].GetValue(e)}");
                for (int i = 1; i < len; i++)
                    if (arr[i].CanRead)
                        str.Append($", {arr[i].Name}: {arr[i].GetValue(e)}");
            }
        }
        str.Append(" }");
        if (is_print) System.Console.Write(str.ToString());
        return str.ToString();
    }
    public static string println(object e)
    {
        var str = print(e, false);
        System.Console.WriteLine(str);
        return str;
    }
}