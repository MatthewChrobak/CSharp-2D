using _2D_Singleplayer_Engine.Audio;
using _2D_Singleplayer_Engine.Graphics;
using System.IO;

namespace _2D_Singleplayer_Engine.IO
{
    public static class FolderSystem
    {
        public static void Check() {
            // Create an array of directories to check.
            string[] folders = {
                                 // General program directories.
                                 Program.StartupPath + "data\\",
                                 Program.StartupPath + "data\\fonts\\",

                                 // Directories pertaining to graphics.
                                 GraphicsManager.SurfacePath,
                                 GraphicsManager.GuiPath,

                                 // Directories pertaining to audio.
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

        // A static method for checking if a file exists. Intended
        // to be used in classes where System.IO is not used, but file
        // existence still needs to be taken into account.
        private static bool FileExists(string file) {
            return File.Exists(file) ? true : false;
        }
    }
}
