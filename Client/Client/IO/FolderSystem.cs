using System.IO;

using Client;
using Graphics;

namespace IO
{
    public static class FolderSystem
    {
        public static void Check() {
            // Create an array of directories to check.
            string[] folders = {
                                 Application.StartupPath + "data\\",
                                 Application.StartupPath + "data\\fonts\\",
                                 GraphicsManager.SurfacePath,
                                 GraphicsManager.ItemPath,
                                 GraphicsManager.TilesetPath,
                                 GraphicsManager.SpritePath,
                                 GraphicsManager.GuiPath,
                                 GraphicsManager.PaperdollPath
                             };

            // Loop through all the directories in the array, and see
            // if they exist. If not, create the directory.
            foreach (string folder in folders) {
                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }
            }
        }

        public static bool FileExists(string file) {
            if (File.Exists(file)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
