public class type_string
{

    [Xunit.Fact]
    public static void run()
    {
        string s = @"hello ""world"".";
        utils.print(s);
    }
}