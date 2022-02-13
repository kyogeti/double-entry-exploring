using System;
using System.Collections.Generic;

namespace DoubleEntry.Broker
{
    public interface IEventBrokerRepository
    {
        void InsertEvents(IList<BaseEvent> events);
        IList<BaseEvent> ReadEvents(DateTime since);
        IList<BaseEvent> ReadEvents(Type eventType);
    }
}