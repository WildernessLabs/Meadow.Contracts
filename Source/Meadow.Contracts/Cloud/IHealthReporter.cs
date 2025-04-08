using System;
using System.Threading.Tasks;

namespace Meadow.Cloud;

/// <summary>
/// Logic responsible for reporting device health metrics to Meadow.Cloud.
/// </summary>
public interface IHealthReporter
{
    /// <summary>
    /// Starts the health reporter based on the desired interval.
    /// </summary>
    /// <param name="interval">In minutes</param>
    Task Start(int interval);

    /// <summary>
    /// Can be called to manually send a health report event.
    /// </summary>
    /// <returns></returns>
    Task Send();

    /// <summary>
    /// Add a custom health metric.
    /// </summary>
    /// <param name="name">Metric name.</param>
    /// <param name="func">Function to calculate metric value.</param>
    /// <returns></returns>
    bool AddMetric(string name, Func<object> func);

    /// <summary>
    /// Add a custom health metric.
    /// </summary>
    /// <param name="name">Metric name.</param>
    /// <param name="func">Function to calculate the metric value.</param>
    /// <returns></returns>
    bool AddMetric(string name, Func<Task<object>> func);
}