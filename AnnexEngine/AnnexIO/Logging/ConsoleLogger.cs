using AnnexEngine.IO.Logging.Behaviours;
using System;
using System.IO;

namespace AnnexEngine.IO.Logging
{
    /// <summary>
    /// A decoratable logging object that displays entries on the standard input/output stream.
    /// </summary>
    public class ConsoleLogger : LoggerDecorator
    {
        /// <summary>
        /// Initializes a logging object that displays log entries on the standard input/output stream.
        /// </summary>
        public ConsoleLogger() : this(null) { }

        /// <summary>
        /// Initializes a logging object that displays log entries on the standard input/output stream, and passes the log message to its decorated logger.
        /// </summary>
        /// <param name="decoratedLogger">The object to decorate.</param>
        public ConsoleLogger(LoggerDecorator decoratedLogger) : base(decoratedLogger) { }

        /// <summary>
        /// Writes the given message to the standard input/output stream.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public override void WriteWithoutFormat(string message)
        {
            Console.WriteLine(message);
        }

        /// /// <summary>
        /// Basic string formatting that adds information about the sourcefile and calling method to the given message.
        /// </summary>
        /// <param name="message">The given message.</param>
        /// <param name="callerSourceFile">The full path of the caller's source file at compilation.</param> 
        /// <param name="callerName">The calling method's name.</param>
        /// <param name="callerLineNumber">The line number of the method call - unused, but necessary for overriding.</param>
        /// <returns>A formatted log entry.</returns>
        protected override string FormatMessage(string message, string callerSourceFile, string callerName, int callerLineNumber)
        {
            return $"[{Path.GetFileNameWithoutExtension(callerSourceFile)}::{callerName}] - {message}";
        }
    }
}
