using SingleplayerEngine.Audio;
using SingleplayerEngine.Graphics;
using System.IO;

namespace SingleplayerEngine.IO
{
    public static class FolderSystem
    {
        public static void Check() {
            // Create an array of directories to check.
            string[] folders = {
                // General program directories.
                Game.DataPath,

                // Directories needed for data.

                // Directories needed for graphics.
                GraphicsManager.SurfacePath,
                GraphicsManager.GuiPath,
                GraphicsManager.FontPath,

                // Directories needed for music.
                AudioManager.AudioDir,
                AudioManager.MusicDir,
                AudioManager.SoundDir

            };

            // Loop through all the directories in the array, and see
            // if they exist. If not, create the directory.
            foreach (string folder in folders) {
                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }
            }
        }
    }
}
