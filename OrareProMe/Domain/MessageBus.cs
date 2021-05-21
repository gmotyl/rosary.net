using System;

namespace OrareProMe.Domain
{

    public interface IBus
    {
        void Send(string message);
    }

    // Wrapper on top of SDK library
    public class Bus : IBus
    {
        public void Send(string message)
        {
            // Put the message on the Bus instead
            Console.WriteLine($"Message sent: '{message}'");
        }
    }

    // Contains all domain specific messages
    public class MessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void SendIntentionAddedMessage(long intentionId, string title)
        {
            _bus.Send(
                "Type: INTENTION_ADDED;" +
                $"Id: {intentionId}" +
                $"Title: {title}"
            );
        }

        public void SendGeneralMessage(long entityId, string message)
        {
            _bus.Send(
                "Type: Default handler for message;" +
                $"entity Id: {entityId}" +
                $"Messaage: {message}"
            );
        }
    }
}