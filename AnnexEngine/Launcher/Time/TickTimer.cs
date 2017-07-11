using AnnexEngine.Launcher.Time.Behaviour;
using System;

namespace AnnexEngine.Launcher.Time
{
    /// <summary>
    /// A timer object that uses the system's tick count.
    /// </summary>
    public class TickTimer : Timer
    {
        /// <summary>
        /// The last system tickcount.
        /// </summary>
        private int _tickStartTime;

        /// <summary>
        /// Measures time elapsed from its moment of creation, or its last reset.
        /// </summary>
        public TickTimer()
        {
            this.Reset();
        }

        public override int CheckElapsedTime()
        {
            int tick = Environment.TickCount;

            // When the system's tick exceeds the value of an integer, it overflows, making the current tick less than the starting tick.
            // This happens roughly every 24 days or so. If this is the case, apply a different calculation.
            // BUG: Results for the CheckElapsedTime method will produce faulty results when the system is on for roughly 48 days. 
            if (this._tickStartTime > tick) {
                return (int.MaxValue - this._tickStartTime) + (tick - int.MinValue);
            }

            // Otherwise, use the normal formula.
            return tick - this._tickStartTime;
        }

        public override void Reset()
        {
            // Start measuring elapsed time from the current tick.
            this._tickStartTime = Environment.TickCount;
        }
    }
}
