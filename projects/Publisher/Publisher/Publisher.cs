namespace Publisher.Publisher;

using MessageClient;

public class Publisher<TMessage> : IDisposable
{
    private readonly MessageClient<TMessage> _messageClient;

    public Publisher(MessageClient<TMessage> messageClient)
    {
        _messageClient = messageClient;
    }

    public void Connect()
    {
      _messageClient.Connect();
    }

    public void Publish(TMessage message)
    {
        _messageClient.Send(message);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}