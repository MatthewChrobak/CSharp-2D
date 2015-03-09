using System.IO;
using System.IO.Compression;

namespace Server.IO
{
    public static class Compression
    {
        public static void CompressDirectory(string directory, string zipFile) {
            // Check if the directory exists.
            if (Directory.Exists(directory)) {
                ZipFile.CreateFromDirectory(directory, zipFile, CompressionLevel.Optimal, false);
            }
        }

        public static void DecompressDirectory(string zipFile, string directory) {
            
            // If the directory does not exist, creat it.
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            // Extract the zipped file's contents to the directory.
            ZipFile.ExtractToDirectory(zipFile, directory);
        }


        public static void Compress(string file) {

            // Make sure that the file exists.
            if (!File.Exists(file)) {
                return;
            }

            // Open the filestream of the file we want to compress.
            using (var fs = new FileInfo(file).OpenRead()) {
                // Create a new filestream with the .zip file extention.
                using (var newFs = new FileStream(file + ".zip", FileMode.OpenOrCreate)) {
                    // Don't exactly understand this bit, but it works gosh darn it.
                    using (var compressedFs = new GZipStream(newFs, CompressionMode.Compress)) {
                        // Copy whatever we did on the previous like to the original filestream.
                        fs.CopyTo(compressedFs);
                    }
                }
            }
        }
    }
}
