using MessageClient.Drivers;

namespace MessageClient;

public class MessageClient<TMessage>: IDisposable
{
    private readonly IDriver<TMessage> _driver;

    public MessageClient(IDriver<TMessage> driver)
    {
        _driver = driver;
    }

    public void Connect()
    {
      _driver.Connect();
    }
    
    public void ConnectAndListen(Action<TMessage> callback)
    {
      _driver.Connect();
      _driver.Listen(callback);
    }
    
    public void Send(TMessage message)
    {
      _driver.Send(message);
    }

    public void Dispose()
    {
      if (!_driver.Connected())
        return;
      _driver.Disconnect();
    }
}
