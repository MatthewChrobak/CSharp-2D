using System.Runtime.CompilerServices;

namespace AnnexEngine.IO.Logging.Behaviours
{
    /// <summary>
    /// A abstract decoratable logging object.
    /// </summary>
    public abstract class LoggerDecorator : Logger
    {
        /// <summary>
        /// The decorated logging object.
        /// </summary>
        private LoggerDecorator _decoratedLogger;

        /// <summary>
        /// Initializes a logging object that decorates the given object.
        /// </summary>
        /// <param name="decoratedLogger"></param>
        public LoggerDecorator(LoggerDecorator decoratedLogger)
        {
            this._decoratedLogger = decoratedLogger;
        }

        /// <summary>
        /// Directly stores or displays the log entry, and passes the log message to its decorated logger if it exists.
        /// </summary>
        /// <param name="message">The given message.</param>
        /// <param name="callerSourceFile">The full path of the caller's source file at compilation.</param> 
        /// <param name="callerName">The calling method's name.</param>
        /// <param name="callerLineNumber">The line number of the method call.</param>
        public sealed override void Write(string message, [CallerFilePath] string callerSourceFile = "", [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            // Pass the arguments to the decorator's instance of the logger.
            this._decoratedLogger?.Write(message, callerSourceFile, callerName, callerLineNumber);

            // Apply our own formatting to the message, and enter the log.
            this.WriteWithoutFormat(this.FormatMessage(message, callerSourceFile, callerName, callerLineNumber));
        }
    }
}



