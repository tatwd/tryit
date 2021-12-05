using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class n10_parallel_tasks
{
    [Fact]
    public void simple_sum_compare_parallel_sum()
    {
        var watcher = new Stopwatch();
        const int N = 1000000;

        // 普通求和
        watcher.Start();
        var sum1 = 0;
        for (var i = 0; i < N; i++)
        {
            sum1 += i;
        }
        watcher.Stop();
        var elapsed1 = watcher.ElapsedMilliseconds;


        // 并行求和
        watcher.Restart();
        var sum2 = 0;
        // var mutex = new object();
        // Parallel.For(0, 10000, (n) =>
        // {
        //     lock (mutex)
        //         sum2 += n;
        // });
        // Parallel.For(0, N,
        //     localInit: () => 0,
        //     body: (n, state, localVal) => localVal + n,
        //     localFinally: (localVal) => {
        //         lock (mutex)
        //             sum2 += localVal;
        //     });
        Parallel.For(0, N,
            localInit: () => 0,
            body: (n, state, localVal) => localVal + n,
            localFinally: (localVal) => {
                Interlocked.Add(ref sum2, localVal);
            });
        // var values = Enumerable.Range(0, N).ToArray();
        // var customPartitioner = Partitioner.Create(values, true);

        // foreach( var val in customPartitioner.AsParallel())
            // sum2 += val;
        // sum2 = values.AsParallel().WithDegreeOfParallelism(4).Sum();
        watcher.Stop();
        var elapsed2 = watcher.ElapsedMilliseconds;

        Assert.Equal(sum1, sum2);
        Assert.True(elapsed2 < elapsed1);

    }

    [Fact]
    public void parallel_cancel()
    {
        Assert.Throws<OperationCanceledException>(() =>
        {
            // 15s 超时
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            // var options = new ParallelOptions
            // {
            //     // 最大并行度
            //     MaxDegreeOfParallelism = 4,
            //     // 取消令牌
            //     CancellationToken = cts.Token
            // };
            // Parallel.For(0, 10000, options, (n) =>
            // {
            //     Thread.Sleep(1000);
            // });
            Enumerable.Range(0, 10000)
                .AsParallel()
                .WithCancellation(cts.Token)
                .WithDegreeOfParallelism(4)
                .ForAll(n =>
                {
                    Thread.Sleep(1000);
                });
        });

    }



    [Fact]
    public void task_cancel()
    {
        Assert.Throws<OperationCanceledException>(() =>
        {
            // 15s 超时
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            Task.Run(() =>
            {
                Console.WriteLine("task start");
                Thread.Sleep(10 * 1000);
                // cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine("task end");
            }, cts.Token).Wait(cts.Token);
        });

    }

}