class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        
        basic.run();
        
        stopwatch.Stop();
        System.Console.WriteLine("\nElapsed: {0}ms", stopwatch.ElapsedMilliseconds);
    }
}