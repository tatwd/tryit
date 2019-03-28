class multi_threading
{
    static int count { set; get; }

    static int thid => System.Threading.Thread.CurrentThread.ManagedThreadId; // GetHashCode()

    public static void run()
    {
        // 主线线程
        System.Console.WriteLine("A #{0}: {1}", thid, count++);

        var facory = new System.Threading.Tasks.TaskFactory();

        facory.StartNew(() => {
            // System.Threading.Thread.Sleep(1 * 1000);

            // 子线程
            System.Console.WriteLine("B #{0}: {1}", thid, count);
        });

        facory.StartNew(() => {
            // 子线程
            System.Console.WriteLine("C #{0}: {1}", thid, count++);
        });

        System.Threading.Thread.Sleep(10 * 1000);
    }
}