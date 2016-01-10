using System.IO;
using System.IO.Compression;

namespace Client.IO
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

        public static void DecompressFile(string file, bool delete = false) {
            // Make sure the file exists and that it's a zip file.
            if (!File.Exists(file) ||  !file.EndsWith(".zip")) {
                throw new FileNotFoundException("Compression: " + file);
            } 

            // Open the filestream of the file we want to decompress.
            using (var ofs = new FileInfo(file).OpenRead()) {
                // Create a new filestream without the .zip file extention.
                using (var fs = new FileStream(file.Remove(file.Length - 4), FileMode.OpenOrCreate)) {
                    // Create a GZipStream which decompresses the original filestream.
                    using (var gzs = new GZipStream(ofs, CompressionMode.Decompress)) {
                        // Copy our decompressed filestream into the new filestream.
                        gzs.CopyTo(fs);
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
