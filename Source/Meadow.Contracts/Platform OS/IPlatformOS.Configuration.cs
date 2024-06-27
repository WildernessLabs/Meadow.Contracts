namespace Meadow
{
    public partial interface IPlatformOS
    {
        /// <summary>
        /// Enumeration indicating the possible configuration items that can be read / written.
        /// </summary>
        /// <remarks>It is critical that this enum matches the enum in the NuttX file hcom_nx_config_manager.h.</remarks>
        public enum ConfigurationValues
        {
            /// <summary>
            /// Device name configuration value.
            /// </summary>
            DeviceName = 0,

            /// <summary>
            /// Product configuration value.
            /// </summary>
            Product,

            /// <summary>
            /// Model configuration value.
            /// </summary>
            Model,

            /// <summary>
            /// OS version configuration value.
            /// </summary>
            OsVersion,

            /// <summary>
            /// Build date configuration value.
            /// </summary>
            BuildDate,

            /// <summary>
            /// Processor type configuration value.
            /// </summary>
            ProcessorType,

            /// <summary>
            /// Unique ID configuration value.
            /// </summary>
            UniqueId,

            /// <summary>
            /// Serial number configuration value.
            /// </summary>
            SerialNumber,

            /// <summary>
            /// Coprocessor type configuration value.
            /// </summary>
            CoprocessorType,

            /// <summary>
            /// Coprocessor firmware version configuration value.
            /// </summary>
            CoprocessorFirmwareVersion,

            /// <summary>
            /// Mono version configuration value.
            /// </summary>
            MonoVersion,

            /// <summary>
            /// Automatically start network configuration value.
            /// </summary>
            AutomaticallyStartNetwork,

            /// <summary>
            /// Automatically reconnect configuration value.
            /// </summary>
            AutomaticallyReconnect,

            /// <summary>
            /// Maximum network retry count configuration value.
            /// </summary>
            MaximumNetworkRetryCount,

            /// <summary>
            /// Get time at startup configuration value.
            /// </summary>
            GetTimeAtStartup,

            /// <summary>
            /// MAC address configuration value.
            /// </summary>
            MacAddress,

            /// <summary>
            /// Soft AP MAC address configuration value.
            /// </summary>
            SoftApMacAddress,

            /// <summary>
            /// Default access point configuration value.
            /// </summary>
            DefaultAccessPoint,

            /// <summary>
            /// Reset reason configuration value.
            /// </summary>
            ResetReason,

            /// <summary>
            /// Reboot on unhandled exception configuration value.
            /// </summary>
            RebootOnUnhandledException,

            /// <summary>
            /// Initialization timeout configuration value.
            /// </summary>
            InitializationTimeout,

            /// <summary>
            /// Selected network configuration value.
            /// </summary>
            SelectedNetwork,

            /// <summary>
            /// Static IP address configuration value.
            /// </summary>
            StaticIpAddress,

            /// <summary>
            /// Subnet mask configuration value.
            /// </summary>
            SubnetMask,

            /// <summary>
            /// Default gateway configuration value.
            /// </summary>
            DefaultGateway,

            /// <summary>
            /// SD storage supported configuration value.
            /// </summary>
            SdStorageSupported,

            /// <summary>
            /// Reserved pins configuration value.
            /// </summary>
            ReservedPins,

            /// <summary>
            /// Time period that the NTP client attempts to query the NTP time server(s)
            /// </summary>
            NtpRefreshPeriodSeconds
        }


        /// <summary>
        /// Enumeration representing the available network connection types.
        /// </summary>
        public enum NetworkConnectionType
        {
            /// <summary>
            /// WiFi network connection
            /// </summary>
            WiFi = 0,
            /// <summary>
            /// Ethernet network connection
            /// </summary>
            Ethernet,
            /// <summary>
            /// Cell network connection
            /// </summary>
            Cell
        }


        /// <summary>
        /// Get a configuration value, as specified in meadow.config.yaml, from the OS.
        /// </summary>
        /// <typeparam name="T">Type of the object being retrieved.</typeparam>
        /// <param name="item">Item to retrieve.</param>
        /// <returns>Value for the specified item.</returns>
        T GetConfigurationValue<T>(ConfigurationValues item) where T : struct;

        /// <summary>
        /// Send a configuration value to the OS.
        /// </summary>
        /// <typeparam name="T">Type of the object being set.</typeparam>
        /// <param name="item">Item to set.</param>
        /// <param name="value">Value of item.</param>
        void SetConfigurationValue<T>(ConfigurationValues item, T value) where T : struct;

        // named properties

        /// <summary>
        /// OS version.
        /// </summary>
        string OSVersion { get; }

        /// <summary>
        /// OS build date and time.
        /// </summary>
        string OSBuildDate { get; }

        /// <summary>
        /// .NET Runtime version install on the device.
        /// </summary>
        string RuntimeVersion { get; }

        /// <summary>
        /// Should the system reboot on an exception?
        /// </summary>
        bool RebootOnUnhandledException { get; }

        /// <summary>
        /// Number of seconds allowed for the system to initialize.
        /// </summary>
        uint InitializationTimeout { get; }

        /// <summary>
        /// Should a WiFi connection be made on startup.
        /// </summary>
        /// <remarks>This assumes that the default access point is configured through wifi.config.yaml.</remarks>
        bool AutomaticallyStartNetwork { get; }

        /// <summary>
        /// Which network is selected in meadow.config.yaml.
        /// </summary>
        public NetworkConnectionType SelectedNetwork { get; }

        /// <summary>
        /// Should SD card support be enabled on this platform?
        /// </summary>
        public bool SdStorageSupported { get; }

        /// <summary>
        /// Names of any pins that should be reserved for OS use.
        /// </summary>
        /// <remarks>This should be a semicolon list of pin names that will be reserved for OS use.</remarks>
        public string ReservedPins { get; }

        /// <summary>
        /// Gets a list of NTP servers used for time synchronization
        /// </summary>
        public string[] NtpServers { get; }
    }
}
