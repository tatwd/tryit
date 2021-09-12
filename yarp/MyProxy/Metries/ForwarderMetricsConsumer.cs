using System;
using Yarp.ReverseProxy.Telemetry.Consumption;

public sealed class ForwarderMetricsConsumer : IForwarderMetricsConsumer
{
    public void OnForwarderMetrics(ForwarderMetrics oldMetrics, ForwarderMetrics newMetrics)
    {
        var elapsed = newMetrics.Timestamp - oldMetrics.Timestamp;
        var newRequests = newMetrics.RequestsStarted - oldMetrics.RequestsStarted;
        Console.Title = $"Forwarded {newMetrics.RequestsStarted} requests ({newRequests} in the last {(int)elapsed.TotalMilliseconds} ms)";
    }
}
