using System;
using System.Collections.Generic;
using System.Linq;
using DoubleEntry.Common.Exceptions;

namespace DoubleEntry.Broker
{
    public class EventBroker : IEventBroker
    {
        private readonly IEventBrokerRepository _repository;

        public EventBroker(IEventBrokerRepository repository)
        {
            _repository = repository;
        }

        public IList<BaseEvent> EventsCommitted { get; set; } = new List<BaseEvent>();
        public IList<BaseEvent> EventsToCommit { get; set; } = new List<BaseEvent>();

        public void CommitEvents(IList<BaseEvent> events)
        {
            foreach (var @event in EventsToCommit)
            {
                CheckDuplicatedBeforeCommit();
            }

            _repository.InsertEvents(events);
        }

        public void CheckDuplicatedBeforeCommit()
        {
            foreach (var @event in EventsToCommit)
            {
                if (EventsCommitted.Any(x => x.Exists(@event)))
                    throw new DuplicatedEventException();
            }
        }

        public IEnumerable<BaseEvent> GetAllEvents()
        {
            return _repository.ReadEvents(DateTime.MinValue);
        }

        public IEnumerable<BaseEvent> GetEventsBasedOnType(Type eventType)
        {
            return _repository.ReadEvents(eventType);
        }
    }
}