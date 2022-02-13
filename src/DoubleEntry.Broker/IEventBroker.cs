using System;
using System.Collections.Generic;

namespace DoubleEntry.Broker
{
    public interface IEventBroker
    {
        void CommitEvents(IList<BaseEvent> @events);
        void CheckDuplicatedBeforeCommit();
        IEnumerable<BaseEvent> GetAllEvents();
        IEnumerable<BaseEvent> GetEventsBasedOnType(Type eventType);
    }
}