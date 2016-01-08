using Game.Audio;
using Game.Graphics;
using System.IO;

namespace Game.IO
{
    public static class FolderSystem
    {
        public static void Check() {
            // Create an array of directories to check.
            string[] folders = {
                // General program directories.
                Program.DataPath,

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
