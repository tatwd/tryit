class datetime
{
    static void demo_ParseExact()
    {
        var fmt = "yyyyMMdd";
        var str = "20190604";
        var date = System.DateTime.ParseExact(str, fmt,
            System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        System.Console.WriteLine(date);
    }

    public static void run()
    {
        demo_ParseExact();
    }
}