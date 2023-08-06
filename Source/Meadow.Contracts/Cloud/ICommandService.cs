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
    /// <param name="action">
    /// The action to perform when any Meadow command is received.
    /// </param>
    void Subscribe(Action<MeadowCommand> action);

    /// <summary>
    /// Subscribes an action to handle a Meadow command of type T.
    /// </summary>
    /// <typeparam name="T">Type of the meadow command.</typeparam>
    /// <param name="action">
    /// The action to perform when a Meadow command with a command name that matches
    /// the name of type T is received.
    /// </param>
    /// <remarks>
    /// The type name MUST be unique since it corresponds to the command name
    /// used on Meadow.Cloud. If Subscribe is called multiple times for the same
    /// type name (even across namespaces), only the last subscription will be
    /// executed.
    /// </remarks>
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

