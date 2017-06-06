using AnnexEngine.IO.Logging.Behaviours;
using System.IO;

namespace AnnexEngine.IO.Logging
{
    /// <summary>
    /// A decoratable logging object that appends log entries to a given log file.
    /// </summary>
    public class FileLogger : LoggerDecorator
    {
        /// <summary>
        /// The base folder where all log files are kept.
        /// </summary>
        public const string LogFileFolder = "logs/";

        /// <summary>
        /// The log file path for the current logger.
        /// </summary>
        private string _logFilePath;

        /// <summary>
        /// Initializing a logging object that appends log entries to the file specified.
        /// </summary>
        /// <param name="filename">The log file path.</param>
        public FileLogger(string filename) : this(filename, null) { }

        /// <summary>
        /// Initializing a logging object that appends log entries to the file specified, and passes the log message to its decorated logger.
        /// </summary>
        /// <param name="filename">The log file path.</param>
        /// <param name="logger">The object to decorate.</param>
        public FileLogger(string filename, LoggerDecorator logger) : base(logger)
        {
            // Ensure the folder containing the log-file exists, and store the full path.
            FileSystem.ValidateDirectory(this._logFilePath = FileLogger.LogFileFolder + filename);
        }

        /// <summary>
        /// Appends a message to the log file.
        /// </summary>
        /// <param name="message">The message to be appended.</param>
        public override void WriteWithoutFormat(string message)
        {
            File.AppendAllText(this._logFilePath, message);
        }
    }
}
