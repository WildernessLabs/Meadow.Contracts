using System;
using System.Collections.Generic;

namespace Meadow.Cloud;

/// <summary>
/// Represents a generic command that can be sent to a Meadow device through Meadow.Cloud.
/// </summary>
public class MeadowCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeadowCommand"/> class.
    /// </summary>
    /// <param name="commandName">The name of the command to execute.</param>
    /// <param name="arguments">The arguments of the command.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="commandName"/> is null, empty or whitespace.</exception>
    public MeadowCommand(string commandName, IReadOnlyDictionary<string, object>? arguments = null)
    {
        if (string.IsNullOrWhiteSpace(commandName))
        {
            throw new ArgumentException($"'{nameof(commandName)}' cannot be null or whitespace.", nameof(commandName));
        }

        CommandName = commandName;
        Arguments = arguments ?? new Dictionary<string, object>();
    }

    /// <summary>
    /// Gets the name of the command.
    /// </summary>
    public string CommandName { get; }

    /// <summary>
    /// Gets the arguments of the command.
    /// </summary>
    public IReadOnlyDictionary<string, object> Arguments { get; }
}
