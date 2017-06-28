using AnnexEngine.Graphics.Devices;

namespace AnnexEngine.Graphics
{
    /// <summary>
    /// Manages an arbitrary graphical device.
    /// </summary>
    public static class GraphicsManager
    {
        // TODO: Put these paths somewhere else. They have no place here.
        public static readonly string GraphicsPath = "Graphics\\";
        public static readonly string FontPath = "Fonts\\";

        // The graphical device.
        public static IGraphicalDevice Device { private set; get; }

        /// <summary>
        /// Initializes the specified graphical device.
        /// </summary>
        /// <param name="deviceType">The type of graphical device to be initialized.</param>
        public static void InitializeDevice(DeviceType deviceType)
        {
            // Figure out which device is requested, and create it.
            switch (deviceType)
            {
                default:
                    // TODO: Throw an exception if the specified type is unsupported.
                    break;
            }
        }
    }
}
