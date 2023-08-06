using Meadow.Cloud;
using Meadow.Logging;
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
            Services = new ServiceCollection();
            Services.Add(Services);
        }

#pragma warning disable CS8603
        /// <summary>
        /// Retrieves the currently executing IApp instance
        /// </summary>
        public static IApp App
        {
            get => Services?.Get<IApp>();
        }

        /// <summary>
        /// Retrieves the current IMeadowDevice the app is running on
        /// </summary>
        public static IMeadowDevice Device
        {
            get => Services?.Get<IMeadowDevice>();
        }

        /// <summary>
        /// Retrieves the current Logger instance
        /// </summary>
        public static Logger Log
        {
            get => Services?.Get<Logger>();
        }

        /// <summary>
        /// Retrieves the current IUpdateService instance
        /// </summary>
        public static IUpdateService UpdateService
        {
            get => Services?.Get<IUpdateService>();
        }

        /// <summary>
        /// Retrieves the current IMeadowCloudService instance
        /// </summary>
        public static IMeadowCloudService MeadowCloudService
        {
            get => Services?.Get<IMeadowCloudService>();
        }
#pragma warning restore CS8603

        /// <summary>
        /// Retrieves the current ICommandService instance
        /// </summary>
        public static ICommandService? CommandService
        {
            get => Services?.Get<ICommandService>();
        }

    }
}
