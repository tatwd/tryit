测试常见的日志框架，在进行日志级别判断和不判断时，输出日志的性能差异

运行：
```sh
dotnet run -C Release
```

参考结果：
``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Core i3-4030U CPU 1.90GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT

```
|                            Method |       Mean |     Error |     StdDev |     Median |  Gen 0 | Allocated |
|---------------------------------- |-----------:|----------:|-----------:|-----------:|-------:|----------:|
|                      MsLog_WithIf |  20.223 ns | 0.5485 ns |  1.6000 ns |  19.696 ns |      - |         - |
|                   MsLog_WithoutIf | 189.531 ns | 6.2912 ns | 17.9491 ns | 181.215 ns | 0.0355 |      56 B |
|                       NLog_WithIf |   4.836 ns | 0.1583 ns |  0.2894 ns |   4.759 ns |      - |         - |
|                    NLog_WithoutIf |   6.358 ns | 0.1772 ns |  0.1571 ns |   6.351 ns |      - |         - |
|                    Serilog_WithIf |   4.744 ns | 0.1550 ns |  0.1904 ns |   4.708 ns |      - |         - |
|                 Serilog_WithoutIf |  18.424 ns | 0.7311 ns |  2.1212 ns |  17.719 ns |      - |         - |
|    MsLog_DefinedLogMessage_WithIf |  19.617 ns | 0.5719 ns |  1.6592 ns |  19.477 ns |      - |         - |
| MsLog_DefinedLogMessage_WithoutIf |  19.337 ns | 0.1448 ns |  0.1284 ns |  19.333 ns |      - |         - |


不同版本的日志框架表现可能不同！