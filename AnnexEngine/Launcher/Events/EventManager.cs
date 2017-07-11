using System;
using System.Collections.Generic;

namespace AnnexEngine.Launcher.Events
{
    /// <summary>
    /// Manages a collection of events.
    /// </summary>
    public class EventManager
    {
        /// <summary>
        /// The collection of events being managed by the class.
        /// </summary>
        private List<IntervalEvent> _events = new List<IntervalEvent>();

        /// <summary>
        /// Probes every event managed by the object for invocation.
        /// </summary>
        internal void ProcessEvents()
        {
            foreach (var e in this._events) {
                e.Update();
            }
        }

        // TODO: Change this to accept an interface/abstract class for a game event, instead of assuming we want a synchronous interval event every time.
        /// <summary>
        /// Adds an event to be managed by the object.
        /// </summary>
        /// <param name="interval">The space of time between each invocation of the event.</param>
        /// <param name="e">The event to be managed by the object.</param>
        public void AddEvent(int interval, Action e)
        {
            this._events.Add(new IntervalEvent(interval, e));
        }
    }
}
