using MessageClient;

namespace Subscriber.Subscriber
{
    public class Subscriber<TMessage> : IDisposable
    {
        private readonly MessageClient<TMessage> _messageClient;
        
        public Subscriber(MessageClient<TMessage> messageClient)
        {
          _messageClient = messageClient;
        }

        public void Subscribe(Action<TMessage> handler)
        {
          _messageClient.ConnectAndListen(handler);
        }

        public void Dispose()
        {
          throw new NotImplementedException();
        }
    }
}