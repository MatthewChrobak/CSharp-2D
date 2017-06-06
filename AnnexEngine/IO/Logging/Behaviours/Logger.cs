using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AnnexEngine.IO.Logging.Behaviours
{
    /// <summary>
    /// Provides basic utility for logging objects to store or display detailed debugging information at runtime.
    /// </summary>
    public abstract class Logger
    {
        /// <summary>
        /// Takes in a message and additional meta-data to add a formatted entry into the log.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <param name="callerSourceFile">The full path of the caller's source file at compilation.</param> 
        /// <param name="callerName">The calling method's name.</param>
        /// <param name="callerLineNumber">The line number of the method call.</param>
        public virtual void Write(string message, [CallerFilePath] string callerSourceFile = "", [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            this.WriteWithoutFormat(this.FormatMessage(message, callerSourceFile, callerName, callerLineNumber));
        }

        /// <summary>
        /// Directly stores or displays the log entry.
        /// </summary>
        /// <param name="message">The log entry to be stored or displayed.</param>
        public abstract void WriteWithoutFormat(string message);

        /// <summary>
        /// Basic string formatting that adds a date/timestamp as well as information about the sourcefile, calling method, and the line number of the caller to the given message.
        /// </summary>
        /// <param name="message">The given message.</param>
        /// <param name="callerSourceFile">The full path of the caller's source file at compilation.</param> 
        /// <param name="callerName">The calling method's name.</param>
        /// <param name="callerLineNumber">The line number of the method call.</param>
        /// <returns>A formatted log entry.</returns>
        protected virtual string FormatMessage(string message, string callerSourceFile, string callerName, int callerLineNumber)
        {
            return $"{DateTime.Now.ToString()} [{Path.GetFileNameWithoutExtension(callerSourceFile)}::{callerName} line {callerLineNumber}] - {message}";
        }
    }
}
