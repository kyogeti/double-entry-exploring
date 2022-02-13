using System;
using Newtonsoft.Json;

namespace DoubleEntry.Broker
{
    public abstract class BaseEvent
    {
        public Type EventType { get; set; }
        public DateTime GeneratedAt { get; }
        public Guid EventId { get; }
        public string Payload { get; private set; }

        protected BaseEvent(string payload)
        {
            GeneratedAt = DateTime.Now;
            EventId = Guid.NewGuid();
            Payload = payload;
        }

        public abstract bool IsEventValid(BaseEvent @event);
        public abstract BaseEvent BuildEvent(BaseEvent @event);
        public abstract bool Exists(BaseEvent comparedEvent);
        public virtual string SerializePayload(object payload) => JsonConvert.SerializeObject(payload);
        public virtual T DeserializePayload<T>() => JsonConvert.DeserializeObject<T>(Payload);
    }
}