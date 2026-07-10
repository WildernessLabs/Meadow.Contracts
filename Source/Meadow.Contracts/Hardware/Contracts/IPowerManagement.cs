using System.Threading.Tasks;

namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for devices that support power management operations such as
    /// ordered shutdown and reboot.
    /// </summary>
    public interface IPowerManagement
    {
        /// <summary>
        /// Called by MeadowOS after the app has shut down cleanly. Implementations
        /// should use this to power off the underlying hardware.
        /// </summary>
        Task OnShutdown();

        /// <summary>
        /// Called by MeadowOS to reboot the underlying hardware.
        /// </summary>
        Task Reset();
    }
}
