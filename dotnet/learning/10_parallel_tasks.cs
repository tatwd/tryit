class parallel_tasks
{
    static int N = 10000;

    static int all = 0;

    static void sum(int n)
    {
        all += n;
        // System.Console.WriteLine(n);
    }

    public static void run()
    {
        var watcher = new System.Diagnostics.Stopwatch();

        // watcher.Start();
        // for (int i = 0; i < N; i++) {
        //     all += i;
        // }
        // watcher.Stop();
        // System.Console.WriteLine("A: all: {0} elapsed: {1}ms", all, watcher.ElapsedMilliseconds);

        // all = 0;

        watcher.Start();
        System.Threading.Tasks.Parallel.For(0, N, sum);
        watcher.Stop();
        System.Console.WriteLine("B: all: {0} elapsed: {1}ms", all, watcher.ElapsedMilliseconds);

        // System.Threading.Thread.Sleep(10 * 1000);
    }
}