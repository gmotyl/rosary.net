using System;
using System.Collections.Generic;
using System.Linq;

namespace OrareProMe.Domain
{
    // Converts domain events into side effects
    public class EventDispatcher
    {
        private readonly MessageBus _messageBus;

        public EventDispatcher(MessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Dispatch(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        public void Dispatch(IDomainEvent ev)
        {
            switch (ev)
            {
                case IntentionAdded intentionAdded:
                    _messageBus.SendIntentionAddedMessage(intentionAdded.IntentionId, intentionAdded.Title);
                    break;
                case PrayerReserved prayerReserved:
                    _messageBus.SendGeneralMessage(prayerReserved.IntentionId, "Prayer reserved");
                    break;
                default:
                    throw new Exception($"Unkown event type {ev.GetType()}");
            }
        }
    }
}