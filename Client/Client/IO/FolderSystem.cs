using System.IO;

namespace Client.IO
{
    public static class FolderSystem
    {
        public static void Check() {
            // Create an array of directories to check.
            string[] folders = {
                                 "data\\",
                                 "data\\surfaces\\",
                                 "data\\fonts\\"
                             };

            // Loop through all the directories in the array, and see
            // if they exist. If not, create the directory.
            foreach (string folder in folders) {
                if (!Directory.Exists(Client.StartupPath + folder)) {
                    Directory.CreateDirectory(Client.StartupPath + folder);
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
