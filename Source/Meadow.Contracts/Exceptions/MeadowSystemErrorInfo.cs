using System;

namespace Meadow;

/// <summary>
/// Contains information about a Meadow system error
/// </summary>
public class MeadowSystemErrorInfo
{
    /// <summary>
    /// Meadow system error numbers
    /// </summary>
    public enum SystemErrorNumber
    {
        /// <summary>
        /// A general/non-specific error
        /// </summary>
        GeneralError = -1,
        /// <summary>
        /// The coprocessor generated an error
        /// </summary>
        CoprocessorError = 1,
        /// <summary>
        /// Meadow Cloud generated an error
        /// </summary>
        MeadowCloudError = 2
    }

    /// <summary>
    /// The error message
    /// </summary>
    public string Message { get; }
    /// <summary>
    /// The system error number associated with the error
    /// </summary>
    public SystemErrorNumber ErrorNumber { get; }
    /// <summary>
    /// Optinal exception information associated with the error
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Creates a MeadowSystemErrorInfo object
    /// </summary>
    /// <param name="message">The error info</param>
    /// <param name="systemErrorNumber">The system error number</param>
    /// <param name="exception">Optional exception information</param>
    public MeadowSystemErrorInfo(
        string message,
        SystemErrorNumber systemErrorNumber = SystemErrorNumber.GeneralError,
        Exception? exception = null)
    {
        Message = message;
        ErrorNumber = systemErrorNumber;
        Exception = exception;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var s = $"{this.GetType().Name} ({ErrorNumber}): {Message}";
        if (Exception != null)
        {
            s += $"{Environment.NewLine}Inner: {Exception.GetType().Name}: {Exception.Message}";
        }

        return s;
    }
}
