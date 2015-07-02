using System.IO;
using System.IO.Compression;

namespace _2D_Multiplayer_Engine_Client.IO
{
    public static class Compression
    {
        public static void CompressDirectory(string directory, string file) {
            // Check if the directory exists.
            if (Directory.Exists(directory)) {
                ZipFile.CreateFromDirectory(directory, file, CompressionLevel.Optimal, false);
            }
        }

        public static void DecompressDirectory(string file, string directory) {
            // If the directory does not exist, create it.
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            // Extract the zipped file's contents to the directory.
            ZipFile.ExtractToDirectory(file, directory);
        }

        public static void CompressFile(string file) {

            // Make sure that the file exists.
            if (!File.Exists(file)) {
                return;
            }

            // Open the filestream of the file we want to compress.
            using (var ofs = new FileInfo(file).OpenRead()) {
                // Create a new filestream with the .zip file extention.
                using (var fs = new FileStream(file + ".zip", FileMode.OpenOrCreate)) {
                    // Create a new filestream as a gZip stream.
                    using (var gzs = new GZipStream(fs, CompressionMode.Compress)) {
                        // Copy our original filestream into the new zGip stream.
                        ofs.CopyTo(gzs);
                    }
                }
            }
        }

        public static void DecompressFile(string file, byte[] array) {

            // Take our byte array and make it a file.
            File.WriteAllBytes(file + ".zip", array);

            // Open the filestream of the file we want to decompress.
            using (var ofs = new FileInfo(file + ".zip").OpenRead()) {
                // Create a new filestream with the .zip file extention.
                using (var fs = new FileStream(file + ".zip", FileMode.OpenOrCreate)) {
                    // Create a new filestream as a gZip stream.
                    using (var gzs = new GZipStream(fs, CompressionMode.Decompress)) {
                        // Copy our original filestream into the new gZip stream.
                        ofs.CopyTo(gzs);
                    }
                }
            }
        }

        public static void DecompressFile(string file, byte[] array, bool delete) {
            DecompressFile(file, array);

            if (delete) {
                File.Delete(file);
            }
        }
    }
}
