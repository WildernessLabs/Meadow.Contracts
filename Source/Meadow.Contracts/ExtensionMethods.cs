using System;
using System.Collections.Generic;
using System.Linq;

namespace Meadow;

/// <summary>
/// ExtensionMethods class
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Contains static extention method to check if the pattern exists within the source
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns>true if the pattern exists</returns>
    // TODO: move this into the `CircularBuffer` class? or is it broadly applicable?
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource[] pattern)
    {
        return (source.FirstIndexOf(pattern) != -1);
    }

    /// <summary>
    /// FirstIndexOf static extention method for an IEnumerable
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns>the index position of the found pattern</returns>
    // TODO: move this into the `CircularBuffer` class? or is it broadly applicable?
    public static int FirstIndexOf<TSource>(this IEnumerable<TSource> source, TSource[] pattern)
    {
        if (pattern == null) throw new ArgumentNullException(nameof(pattern));

        int patternLength = pattern.Length;
        int totalLength = source.Count();
        TSource firstMatch = pattern[0];

        if (firstMatch == null) return -1;

        for (int i = 0; i < totalLength; i++)
        {
            // is this the right equality?
            if ((firstMatch.Equals(source.ElementAt(i))) // begin match?
                 &&
                 (totalLength - i >= patternLength) // can match exist?
               )
            {
                TSource[] matchTest = new TSource[patternLength];
                // copy the potential match into the matchTest array.
                // can't use .Skip() and .Take() because it will actually
                // enumerate over stuff and can have side effects
                for (int x = 0; x < patternLength; x++)
                {
                    matchTest[x] = source.ElementAt(i + x);
                }
                // if the pattern pulled from source matches our search pattern
                // then the pattern exists.
                if (matchTest.SequenceEqual(pattern))
                {
                    return i;
                }
            }
        }
        // if we go here, doesn't exist
        return -1;
    }

    /// <summary>
    /// Maps a source value's position within a range of numbers to the same position
    /// within a another range of numbers. For instance, will map a source value of `30`
    /// in the range of `0` to `100` to a value of `0.3` in a given range of `0.0` to `1.0`.
    /// </summary>
    /// <param name="sourceValue">The value to map to the new domain.</param>
    /// <param name="sourceMin">The minimum value of the source domain.</param>
    /// <param name="sourceMax">The maximum value of the source domain.</param>
    /// <param name="targetMin">The minimum value of the destination domain.</param>
    /// <param name="targetMax">The maximum value of the destination domain.</param>
    /// <returns></returns>
    public static float Map(this float sourceValue, float sourceMin, float sourceMax, float targetMin, float targetMax)
    {
        return (sourceValue - sourceMin) / (sourceMax - sourceMin) * (targetMax - targetMin) + targetMin;
    }

    /// <summary>
    /// Maps a source value's position within a range of numbers to the same position
    /// within a another range of numbers. For instance, will map a source value of `30`
    /// in the range of `0` to `100` to a value of `0.3` in a given range of `0.0` to `1.0`.
    /// </summary>
    /// <param name="sourceValue">The value to map to the new domain.</param>
    /// <param name="sourceMin">The minimum value of the source domain.</param>
    /// <param name="sourceMax">The maximum value of the source domain.</param>
    /// <param name="targetMin">The minimum value of the destination domain.</param>
    /// <param name="targetMax">The maximum value of the destination domain.</param>
    /// <returns></returns>
    public static double Map(this double sourceValue, double sourceMin, double sourceMax, double targetMin, double targetMax)
    {
        return (sourceValue - sourceMin) / (sourceMax - sourceMin) * (targetMax - targetMin) + targetMin;
    }

    /// <summary>
    /// Maps a source value's position within a range of numbers to the same position
    /// within a another range of numbers. For instance, will map a source value of `30`
    /// in the range of `0` to `100` to a value of `0.3` in a given range of `0.0` to `1.0`.
    /// </summary>
    /// <param name="sourceValue">The value to map to the new domain.</param>
    /// <param name="sourceMin">The minimum value of the source domain.</param>
    /// <param name="sourceMax">The maximum value of the source domain.</param>
    /// <param name="targetMin">The minimum value of the destination domain.</param>
    /// <param name="targetMax">The maximum value of the destination domain.</param>
    /// <returns></returns>
    public static int Map(this int sourceValue, int sourceMin, int sourceMax, int targetMin, int targetMax)
    {
        return (sourceValue - sourceMin) / (sourceMax - sourceMin) * (targetMax - targetMin) + targetMin;
    }

    /// <summary>
    /// Traverses the handler's invocation list and invokes each via the EventHandler() method
    /// </summary>
    /// <param name="handler">The delegate we are acting upon.</param>
    /// <param name="args">The arguments we want to pass to each delegate.</param>
    public static void Fire(this Delegate handler, params object[] args)
    {
        EventHandler(handler, args);
    }

    /// <summary>
    /// Traverses the handler's invocation list and invokes each via the EventHandler() method
    /// </summary>
    /// <param name="handler">The eventhandler we are acting upon.</param>
    /// <param name="sender">The sender object.</param>
    public static void Fire(this EventHandler handler, object sender)
    {
        EventHandler(handler, sender, EventArgs.Empty);
    }

    /// <summary>
    /// Traverses the handler's invocation list and invokes each via the EventHandler() method
    /// </summary>
    /// <param name="handler">The eventhandler we are acting upon.</param>
    /// <param name="sender">The sender object.</param>
    /// <param name="args">The arguments we want to pass to each delegate.</param>
    public static void Fire(this EventHandler handler, object sender, EventArgs args)
    {
        EventHandler(handler, sender, args);
    }

    /// <summary>
    /// Traverses the handler's invocation list and invokes each via the EventHandler() method
    /// </summary>
    /// <param name="handler">The eventhandler we are acting upon.</param>
    /// <param name="sender">The sender object.</param>
    /// <param name="args">The arguments we want to pass to each delegate.</param>
    public static void Fire<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
    {
        EventHandler(handler, sender, args);
    }

    /// <summary>
    /// Centralised EventHandler that traverses the handler's invocation list and invokes each with the args
    /// </summary>
    /// <param name="handler">The delegate we are acting upon.</param>
    /// <param name="args">The arguments we want to pass to each delegate.</param>
    private static void EventHandler(Delegate handler, params object[] args)
    {
        if (handler == null)
            return;

        foreach (var d in handler.GetInvocationList())
        {
            try
            {
                d.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
                Resolver.Log.Error($"Event handler threw {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}