using System;

namespace Meadow.Peripherals.Sensors.Buttons
{
    /// <summary>
    /// Interface describing button classes.
    /// </summary>
    public interface IButton : ISensor
    {
        /// <summary>
        /// Raised when a press starts (the button is pushed down; circuit is closed).
        /// </summary>
        event EventHandler PressStarted;

        /// <summary>
        /// Raised when a press ends (the button is released; circuit is opened).
        /// </summary>
        event EventHandler PressEnded;

        /// <summary>
        /// Raised when the button circuit is re-opened after it has been closed (at the end of a “press”.
        /// </summary>
        event EventHandler Clicked;

        /// <summary>
        /// Raised when the button circuit is pressed for at least LongClickedThreshold.
        /// </summary>
        public event EventHandler LongClicked;

        /// <summary>
        /// The minimum duration for a long press.
        /// </summary>
        public TimeSpan LongClickedThreshold { get; set; }
    }
}
