using System.Runtime.InteropServices.JavaScript;

namespace MessageClient.Drivers;

using System;

public interface IDriver<T>
{
    bool Connected();
    void Connect();
    void Disconnect();
    void Listen(Action<T> callback);
    
    void Send(T message);
}