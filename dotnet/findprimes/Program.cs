using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

// namespace findprimes;


if (args.Length == 0)
{
    Console.WriteLine("请设置结束范围数值！");
    return;
}
if (!int.TryParse(args[0], out var end))
{
    Console.WriteLine("请设置有效数值！");
    return;
}

var waitChan = Channel.CreateBounded<bool>(1);
var chan = Channel.CreateUnbounded<int>();

FindPrimes(chan, waitChan);

// publish item to check
for (var i = 2; i < end; i++)
    chan.Writer.TryWrite(i);
chan.Writer.Complete();

await waitChan.Reader.WaitToReadAsync();


void FindPrimes(Channel<int> chan, Channel<bool> waitChan)
{
    Task.Run(async () =>
    {
        // Console.WriteLine("tid:{0}", Thread.CurrentThread.ManagedThreadId);

        // read num from chan
        var ok = await chan.Reader.WaitToReadAsync();
        if (!ok)
        {
            waitChan.Writer.Complete();
            return;
        }

        var prime = await chan.Reader.ReadAsync();
        Console.WriteLine(prime);

        var outChan = Channel.CreateUnbounded<int>();

        FindPrimes(outChan, waitChan);

        while (await chan.Reader.WaitToReadAsync())
        {
            var v = await chan.Reader.ReadAsync();
            if (v % prime != 0)
            {
                outChan.Writer.TryWrite(v);
            }
        }

        outChan.Writer.Complete();
    });
}