using System;
using System.Threading;

namespace Meadow.Update;

/// <summary>
/// Describes a callback delegate for IUpdateService events
/// </summary>
/// <param name="updateService">The IUpdateService raising the event</param>
/// <param name="info">The UpdateInfo associated with the event</param>
/// <param name="cancel">Use to abort the update</param>
public delegate void UpdateEventHandler(IUpdateService updateService, UpdateInfo info, CancellationTokenSource cancel);

/// <summary>
/// Provides an abstraction for the Meadow Update Service
/// </summary>
public interface IUpdateService
{
    /// <summary>
    /// Event raised when an the state of the Update service changes
    /// </summary>
    event EventHandler<UpdateState> StateChanged;
    /// <summary>
    /// Event raised when an update is available on the defined Update server
    /// </summary>
    event UpdateEventHandler UpdateAvailable;
    /// <summary>
    /// Event raised during update file retrieval progress
    /// </summary>
    event UpdateEventHandler RetrieveProgress;
    /// <summary>
    /// Event raised after an update package has been retrieved from the defined Update server
    /// </summary>
    event UpdateEventHandler UpdateRetrieved;
    /// <summary>
    /// Event raised after an update package has been successfully applied
    /// </summary>
    event UpdateEventHandler UpdateSuccess;
    /// <summary>
    /// Event raised if a failure occurs in an attempt to apply an update package
    /// </summary>
    event UpdateEventHandler UpdateFailure;
    /// <summary>
    /// Returns the update service's current ability to apply an update
    /// </summary>
    bool CanUpdate => State == UpdateState.Connected;
    /// <summary>
    /// Gets the current state of the service
    /// </summary>
    UpdateState State { get; }

    /// <summary>
    /// Stops the service
    /// </summary>
    void Stop();
}
