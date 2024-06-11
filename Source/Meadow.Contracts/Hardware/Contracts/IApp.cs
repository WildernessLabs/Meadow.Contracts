using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meadow;

/// <summary>
/// Contract for Meadow applications. Provides a way for the Meadow OS to
/// communicate with Meadow applications when system events are happening.
/// </summary>
public interface IApp
{
    /// <summary>
    /// Use this method to invoke actions on the application's startup thread
    /// </summary>
    /// <param name="action">The action to invoke</param>
    /// <param name="state">Optional state data to pass to the Action</param>
    void InvokeOnMainThread(Action<object?> action, object? state = null);

    /// <summary>
    /// The application's version number
    /// </summary>
    public static Version Version { get; } = new Version("1.0.0");

    /// <summary>
    /// Settings parsed from the app.config.yaml at startup
    /// </summary>
    public Dictionary<string, string> Settings { get; }

    /// <summary>
    /// A cancellation token that is canceled when the application is signaled to shut down
    /// </summary>
    public CancellationToken CancellationToken { get; }

    /// <summary>
    /// Called when the application is being brought up.
    /// </summary>
    public Task Initialize();

    /// <summary>
    /// The core of the app's work and logic
    /// </summary>
    public Task Run();

    /// <summary>
    /// Called if the app is being brought down.
    /// </summary>
    public Task OnShutdown();

    /// <summary>
    /// Called if a failure occurred while running the app
    /// </summary>
    public Task OnError(Exception e);

    /// <summary>
    /// Called when the application is about to update itself.
    /// </summary>
    public void OnUpdate(Version newVersion, out bool approveUpdate);

    /// <summary>
    /// Called when the application has updated itself.
    /// </summary>
    public void OnUpdateComplete(Version oldVersion, out bool rollbackUpdate);
}
