using AnnexEngine.Graphics.Devices;
using System;

namespace AnnexEngine.Launcher.Application.Frameworks
{
    /// <summary>
    /// Defines the behaviour of a singleplayer game client.
    /// </summary>
    public abstract class SingleplayerClient : AppBehaviour
    {
        /// <summary>
        /// Initializes the necessary components for a singleplayer client, and adds necessary game-loop events.
        /// </summary>
        internal sealed override void Setup()
        {
            // TODO: Load game data.
            this.Settings.AddSettingIfNotExists("device", "SFML");

            // TODO: Initialize audio.

            // Initialize the graphics device off of the settings entry.
            GraphicsManager.InitializeDevice((DeviceType)Enum.Parse(typeof(DeviceType), this.Settings.GetSetting("device")));

            // Render the game at 60 fps.
            this.AddEvent(16, () => GraphicsManager.Device.Draw());
        }

        /// <summary>
        /// Saves game data, and destroys all initialized components.
        /// </summary>
        internal sealed override void Exit()
        {
            // TODO: Save game data.

            // TODO: Destroy audio.

            // Destroy the game graphics.
            GraphicsManager.Device.Destroy();
        }
    }
}
