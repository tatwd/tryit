class attributes
{
    class HelpAttribute : System.Attribute
    {
        public string Url { set; get; }
        public string Topic { set; get; } = "default";

        public HelpAttribute(string url)
        {
            Url = url;
        }
    }

    [Help("http://foo.com/widget/index.html")]
    class widget
    {
        [Help("http://foo.com/widget/display.html", Topic = "display")]
        public void display(string text) { }
    }

    static void show_help(System.Reflection.MemberInfo member)
    {
        HelpAttribute attr = System.Attribute.GetCustomAttribute(
            member,
            typeof(HelpAttribute)
        ) as HelpAttribute;
        if (attr == null) utils.print("No help for {0}", member);
        else utils.print(attr);
    }

    public static void run()
    {
        show_help(typeof(widget));
        show_help(typeof(widget).GetMethod("display"));
    }
}