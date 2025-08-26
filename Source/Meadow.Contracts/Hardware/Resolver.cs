using Meadow.Cloud;
using Meadow.Logging;
using Meadow.Peripherals.Sensors;
using Meadow.Update;

namespace Meadow
{
    /// <summary>
    /// Static container for common and user-supplied application services
    /// </summary>
    public static class Resolver
    {
        /// <summary>
        /// A ServiceCollection instance
        /// </summary>
        public static ServiceCollection Services { get; }

        static Resolver()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer, since this breaks the world.
            Services = new ServiceCollection();
            Services.Add(Services);
        }

#pragma warning disable CS8603
        /// <summary>
        /// Retrieves the currently executing IApp instance
        /// </summary>
        public static IApp App => Services?.Get<IApp>();

        /// <summary>
        /// Retrieves the current IMeadowDevice the app is running on
        /// </summary>
        public static IMeadowDevice Device => Services?.Get<IMeadowDevice>();

        /// <summary>
        /// Retrieves the current Logger instance
        /// </summary>
        public static Logger Log => Services?.Get<Logger>();

        /// <summary>
        /// Retrieves the current IUpdateService instance
        /// </summary>
        public static IUpdateService UpdateService => Services?.Get<IUpdateService>();

        /// <summary>
        /// Retrieves the current ISensorService instance
        /// </summary>
        public static ISensorService SensorService => Services?.Get<ISensorService>();

        /// <summary>
        /// Retrieves the current IMeadowCloudService instance
        /// </summary>
        public static IMeadowCloudService MeadowCloudService => Services?.Get<IMeadowCloudService>();

        /// <summary>
        /// Retrieves the current ICommandService instance
        /// </summary>
        public static ICommandService CommandService => Services?.Get<ICommandService>();

        /// <summary>
        /// Retrieves the current IJsonSerializer instance
        /// </summary>
        public static IJsonSerializer JsonSerializer => Services?.Get<IJsonSerializer>();

        /// <summary>
        /// Gets the current instance of the health reporter service.
        /// </summary>
        public static IHealthReporter? HealthReporter => Services?.Get<IHealthReporter>();
#pragma warning restore CS8603
    }
}
