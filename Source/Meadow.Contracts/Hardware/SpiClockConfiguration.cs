﻿using System;
namespace Meadow.Hardware
{
    /// <summary>
    /// Encapsulates properties of a SPI Bus Clock
    /// </summary>
    public class SpiClockConfiguration
    {
        private Units.Frequency _speed;
        private int _bitsPerWord;
        private ClockPhase _phase;
        private ClockPolarity _polarity;

        public event EventHandler Changed = delegate { };

        /// <summary>
        /// SPI Bus Clock Polarity (CPOL)
        /// </summary>
        public enum ClockPolarity
        {
            Normal = 0,
            Inverted = 1
        }

        /// <summary>
        /// SPI Bus Clock Phase (CPHA)
        /// </summary>
        public enum ClockPhase
        {
            Zero = 0,
            One = 1
        }

        /// <summary>
        /// Mode (combination of Phase and Polarity) of a SPI bus clock
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// Normal (0) Polarity, and Phase 0
            /// </summary>
            Mode0,
            /// <summary>
            /// Normal (0) Polarity, and Phase 1
            /// </summary>
            Mode1,
            /// <summary>
            /// Inverted (1) Polarity, and Phase 0
            /// </summary>
            Mode2,
            /// <summary>
            /// Inverted (1) Polarity, and Phase 1
            /// </summary>
            Mode3
        }

        /// <summary>
        /// Gets or sets the current Polarity of the SPI bus clock
        /// </summary>
        public ClockPolarity Polarity
        {
            get => _polarity;
            set
            {
                if (value == Polarity) return;
                _polarity = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the current Phase of the SPI bus clock
        /// </summary>
        public ClockPhase Phase
        {
            get => _phase;
            set
            {
                if (value == Phase) return;
                _phase = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sets the desired speed or gets the actual speed of the SPI bus clock.
        /// </summary>
        /// <remarks>
        /// The set of supported speeds is programmatically available from the bus in the <b>SupportedSpeeds</b> property.
        /// </remarks>
        public Units.Frequency Speed
        {
            get => _speed;
            set
            {
                if (value == Speed) return;
                _speed = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public int BitsPerWord
        {
            get => _bitsPerWord;
            set
            {
                if (value == BitsPerWord) return;
                if (value < 4 || value > 16) throw new ArgumentOutOfRangeException();

                _bitsPerWord = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public Mode SpiMode
        {
            get
            {
                if (Polarity == ClockPolarity.Normal)
                {
                    return (Phase == ClockPhase.Zero) ? Mode.Mode0 : Mode.Mode1;
                }

                return (Phase == ClockPhase.Zero) ? Mode.Mode2 : Mode.Mode3;
            }
        }

        /// <summary>
        /// Provided to allow setting speed value without raising a Changed event. This method is used internally.
        /// </summary>
        /// <param name="speed">The SPI bus speed</param>
        public void SetActualSpeed(Units.Frequency speed)
        {
            _speed = speed;
        }

        /// <summary>
        /// Provided to allow setting the SPI bus mode
        /// </summary>
        /// <param name="mode">The SPI bus mode</param>
        public void SetBusMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.Mode0:
                    Polarity = ClockPolarity.Normal;
                    Phase = ClockPhase.Zero;
                    break;
                case Mode.Mode1:
                    Polarity = ClockPolarity.Normal;
                    Phase = ClockPhase.One;
                    break;
                case Mode.Mode2:
                    Polarity = ClockPolarity.Inverted;
                    Phase = ClockPhase.Zero;
                    break;
                case Mode.Mode3:
                    Polarity = ClockPolarity.Inverted;
                    Phase = ClockPhase.One;
                    break;
            }
        }

        internal SpiClockConfiguration()
        {
        }

        /// <summary>
        /// Creates a SpiClockConfiguration instance
        /// </summary>
        /// <param name="speed">Bus clock speed, in kHz</param>
        /// <param name="polarity">Bus clock polarity</param>
        /// <param name="phase">Bus clock phase</param>
        public SpiClockConfiguration(
            Units.Frequency speed,
            ClockPolarity polarity = ClockPolarity.Normal,
            ClockPhase phase = ClockPhase.Zero
        )
        {
            Speed = speed;
            Polarity = polarity;
            Phase = phase;
            BitsPerWord = 8;
        }

        /// <summary>
        /// Creates a SpiClockConfiguration instance
        /// </summary>
        /// <param name="speed">Bus clock speed, in kHz</param>
        /// <param name="mode">Bus Mode (phase and polarity)</param>
        public SpiClockConfiguration(
            Units.Frequency speed,
            Mode mode
        )
        {
            Speed = speed;
            BitsPerWord = 8;

            SetBusMode(mode);
        }
    }
}