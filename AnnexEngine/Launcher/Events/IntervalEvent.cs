using AnnexEngine.Launcher.Time;
using AnnexEngine.Launcher.Time.Behaviour;
using System;

namespace AnnexEngine.Launcher.Events
{
    /// <summary>
    /// A wrapper for an action object. The action is ran after a specified duration has passed.
    /// The object does not create any threads, and must be probed using the Update method.
    /// </summary>
    public sealed class IntervalEvent
    {
        /// <summary>
        /// The amount of time in milliseconds spent waiting since the last event was run.
        /// </summary>
        private int _elapsedWaitingTime;

        /// <summary>
        /// The interval in milliseconds which the event should run at.
        /// </summary>
        private readonly int _interval;

        /// <summary>
        /// The event managed by the object.
        /// </summary>
        private readonly Action _event;

        /// <summary>
        /// The timer object that helps determine when to run the event-handler.
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Stores the specified interval and given event.
        /// </summary>
        /// <param name="interval">The interval in milliseconds at which the event-handler will be run.</param>
        /// <param name="e">The event to run after the specified interval.</param>
        public IntervalEvent(int interval, Action e)
        {
            // Set the elapsed waiting time to 0.
            this._elapsedWaitingTime = 0;

            // Create a timer to keep track of elapsed time.
            this._timer = new TickTimer();

            // Store the interval and the event.
            this._interval = interval;
            this._event = e;
        }

        /// <summary>
        /// Runs the interval event if the elapsed wait time is equal to or greater than its interval.
        /// </summary>
        public void Update()
        {
            // Get the time elapsed since the last call of Update, and add it to the previous waiting time.
            int elapsedTime = this._timer.CheckElapsedTimeAndReset();
            this._elapsedWaitingTime += elapsedTime;

            // If we've been waiting for the specified interval, invoke the event if it exists.
            // Subtract the interval duration from the total wait time.
            if (this._elapsedWaitingTime >= this._interval) {
                this._event?.Invoke();
                this._elapsedWaitingTime -= this._interval;
            }
        }
    }
}