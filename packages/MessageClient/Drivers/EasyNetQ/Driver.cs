using EasyNetQ;

namespace MessageClient.Drivers.EasyNetQ
{
    public class EasyNetQDriver<TMessage> : IDriver<TMessage>
    {
      private readonly string _connectionString;
      private IBus? _bus;
      private IDisposable _subscriptionResult;
      private readonly MessagingStrategies.MessagingStrategy _messagingStrategy;
      
      public EasyNetQDriver(string connectionString, MessagingStrategies.MessagingStrategy messagingStrategy)
      {
        _connectionString = connectionString;
        _messagingStrategy = messagingStrategy;
      }
      
      public bool Connected()
      {
          // Check if the bus is connected
          return _bus != null;
      }

      public void Connect()
      {
          // Connect to the message broker
          _bus = RabbitHutch.CreateBus(_connectionString);
      }
      
      public void Disconnect()
      {
        // Check if there's a subscription
        if (_subscriptionResult.Equals(null))
        {
          throw new InvalidOperationException("You must call Connect before Disconnect");
        }
        // Disconnect from the message broker
        _subscriptionResult.Dispose();
      }

      public void Listen(Action<TMessage> callback)
      {
          _subscriptionResult = _messagingStrategy.Listen<TMessage>(callback, _bus);
      }
      
      public void Send(TMessage message)
      {
          _messagingStrategy.Send(message, _bus);
      }
    }
}