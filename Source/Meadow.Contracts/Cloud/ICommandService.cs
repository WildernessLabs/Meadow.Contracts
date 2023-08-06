using System;

namespace Meadow.Cloud;

/// <summary>
/// Service responsible for subscribing and unsubscribing to Meadow commands.
/// </summary>
public interface ICommandService
{
    /// <summary>
    /// Subscribes an action to handle a generic Meadow command.
    /// </summary>
    /// <param name="action">Action to subscribe.</param>
    void Subscribe(Action<MeadowCommand> action);

    /// <summary>
    /// Subscribes an action to handle a Meadow command of type T.
    /// </summary>
    /// <typeparam name="T">Type of the meadow command.</typeparam>
    /// <param name="action">Action to subscribe.</param>
    void Subscribe<T>(Action<T> action) where T : IMeadowCommand, new();

    /// <summary>
    /// Unsubscribes an action that handles a Meadow command of type T.
    /// </summary>
    /// <typeparam name="T">Type of the meadow command.</typeparam>
    void Unsubscribe<T>() where T : IMeadowCommand, new();

    /// <summary>
    /// Unsubscribes an action to handle a generic Meadow command.
    /// </summary>
    void Unsubscribe();
}

