namespace AnnexEngine.Launcher.Time.Behaviour
{
    /// <summary>
    /// Keeps track of elapsed-time.
    /// </summary>
    public abstract class Timer
    {
        /// <summary>
        /// Resets the timer so that elapsed time is measured from the last reset. 
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Returns the elapsed time in milliseconds.
        /// </summary>
        /// <returns>The time elapsed since the timer started in milliseconds.</returns>
        public abstract int CheckElapsedTime();

        /// <summary>
        /// Returns the elapsed time in milliseconds, and calls reset.
        /// </summary>
        /// <returns>The time elapsed since the timer started in milliseconds.</returns>
        public int CheckElapsedTimeAndReset()
        {
            // Retrieve the elapsed time.
            int elapsedTime = this.CheckElapsedTime();

            // Reset the timer.
            this.Reset();

            return elapsedTime;
        }
    }
}
