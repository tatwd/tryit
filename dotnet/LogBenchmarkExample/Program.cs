using BenchmarkDotNet.Running;
using LogBenchmarkExample;

BenchmarkRunner.Run<LogBenchmark>();

// new LogBenchmark().MsLog_DefinedLogMessage_WithIf();

