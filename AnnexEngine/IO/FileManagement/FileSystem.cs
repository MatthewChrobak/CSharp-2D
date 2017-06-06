using System.IO;

namespace AnnexEngine.IO.FileManagement
{
    /// <summary>
    /// Provides basic utility methods for interacting with the filesystem.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Creates all directories and sub-directories of the given file or directory path if it does not exist.
        /// </summary>
        /// <param name="path">A file or directory path.</param>
        public static void ValidateDirectory(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    }
}
