using System.IO;
using System.IO.Compression;

namespace Game.IO
{
    public static class Compression
    {
        public static void CompressDirectory(string directory, string zipfile) {
            // Make sure the directory exists before compressing.
            if (Directory.Exists(directory)) { 
                ZipFile.CreateFromDirectory(directory, zipfile, CompressionLevel.Optimal, false);
            } else {
                // If it does not exist, throw an excetion.
                throw new DirectoryNotFoundException("Compression: " + directory);
            }
        }

        public static void DecompressDirectory(string zipfile, string directory) {
            // If the directory does not exist, create it.
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            // Extract the zipped file's contents to the directory.
            ZipFile.ExtractToDirectory(zipfile, directory);
        }

        public static void CompressFile(string zipfile) {
            // Make sure that the file exists.
            if (!File.Exists(zipfile)) {
                throw new FileNotFoundException("Compression: " + zipfile);
            }

            // Open the filestream of the file we want to compress.
            using (var ofs = new FileInfo(zipfile).OpenRead()) {
                // Create a new filestream with the .zip file extention.
                using (var fs = new FileStream(zipfile + ".zip", FileMode.OpenOrCreate)) {
                    // Create a new gZip filestream.
                    using (var gzs = new GZipStream(fs, CompressionMode.Compress)) {
                        // Copy our original filestream into the new gZip stream.
                        ofs.CopyTo(gzs);
                    }
                }
            }
        }

        public static void DecompresBytes(string file, byte[] array, bool delete = false) {
            // take our byte array and make it a file.
            File.WriteAllBytes(file + ".zip", array);

            // Open the filestream of the file we want to decompress.
            using (var ofs = new FileInfo(file + ".zip").OpenRead()) {
                // Create a new filestream with the .zip file extention.
                using (var fs = new FileStream(file + ".zip", FileMode.OpenOrCreate)) {
                    // Create a new filestream as a gZip stream.
                    using (var gzs = new GZipStream(fs, CompressionMode.Decompress)) {
                        // Copy our original filestream into the new gZip stream
                        ofs.CopyTo(gzs);
                    }
                }
            }

            // Unless instructed otherwise, don't delete the original file.
            if (delete) {
                File.Delete(file);
            }
        }
    }
}
