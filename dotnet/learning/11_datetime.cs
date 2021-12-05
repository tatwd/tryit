using System;
using System.Globalization;
using Xunit;

public class n11_datetime
{
    public DateTime demo_ParseExact()
    {
        var fmt = "yyyyMMdd";
        var str = "20190604";
        var date = DateTime.ParseExact(str, fmt,
            CultureInfo.CreateSpecificCulture("en-US"));
        return date;
    }

    [Fact]
    public void demo_ParseExact_test()
    {
        var date = demo_ParseExact();
        Assert.Equal(2019, date.Year);
    }
}