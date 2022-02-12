using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using NLog;
using Serilog;

namespace LogBenchmarkExample;

[MemoryDiagnoser]
public class LogBenchmark
{
    private const string Message = "Hello {year} world!";

    private readonly NLog.ILogger _nLogger;
    private readonly ILogger<LogBenchmark> _msLogger;
    private readonly Serilog.ILogger _sLogger;
    private readonly Action<Microsoft.Extensions.Logging.ILogger, int, Exception> _myHelloLog;

    public LogBenchmark()
    {
        // Microsoft Logger
        _msLogger = LoggerFactory.Create(builder => builder
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
                .AddConsole())
            .CreateLogger<LogBenchmark>();

        // NLog
        _nLogger = LogManager.Setup().SetupInternalLogger(builder =>
            builder.SetMinimumLogLevel(NLog.LogLevel.Warn)
                .LogToConsole(true))
            .GetCurrentClassLogger();

        // Serilog
        _sLogger = new Serilog.LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Console()
            .CreateLogger();

        // Microsoft LoggerMessage.Define
        _myHelloLog = LoggerMessage.Define<int>(Microsoft.Extensions.Logging.LogLevel.Information,
            new EventId(2, nameof(LogBenchmark)),
            Message);

    }

    [Benchmark]
    public void MsLog_WithIf()
    {
        if (_msLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information))
        {
            _msLogger.LogInformation(Message, 2022);
        }
    }

    [Benchmark]
    public void MsLog_WithoutIf()
    {
        _msLogger.LogInformation(Message, 2022);
    }

    [Benchmark]
    public void NLog_WithIf()
    {
        if (_nLogger.IsInfoEnabled)
        {
            _nLogger.Info(Message, 2022);
        }
    }

    [Benchmark]
    public void NLog_WithoutIf()
    {
        _nLogger.Info(Message, 2022);
    }

    [Benchmark]
    public void Serilog_WithIf()
    {
        if (_sLogger.IsEnabled(Serilog.Events.LogEventLevel.Information))
        {
            _sLogger.Information(Message, 2022);
        }
    }

    [Benchmark]
    public void Serilog_WithoutIf()
    {
        _sLogger.Information(Message, 2022);
    }

    [Benchmark]
    public void MsLog_DefinedLogMessage_WithIf()
    {
        if (_msLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information))
        {
            _myHelloLog(_msLogger, 2022, null!);
        }
    }

    [Benchmark]
    public void MsLog_DefinedLogMessage_WithoutIf()
    {
        _myHelloLog(_msLogger, 2022, null!);
    }

}