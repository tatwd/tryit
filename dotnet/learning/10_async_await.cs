using System.Threading.Tasks;

class async_await
{

    static Task<string> StartTask()
    {
        return Task.Run(() => {
            System.Console.WriteLine("Start download!");
            var wc = new System.Net.WebClient();
            return wc.DownloadString("http://www.baidu.com/");
        });
    }

    public static void run()
    {
        var task = StartTask();
        System.Console.WriteLine("Downloading...");
        var result = task.Result;
        System.Console.WriteLine(result);
    }
}