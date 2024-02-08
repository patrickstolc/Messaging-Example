using Subscriber.Subscriber;
using Messages;
using ClientID;

namespace Subscriber
{
    class Program
    {
        static void HandleTextMessage(TextMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Received: {0}", message.Text);
            Console.ResetColor();
        }
        
        static void Main()
        {
            var clientId = ClientId.GetClientId();
            var subscriber = SubscriberFactory.CreateEasyNetQSubscriber<TextMessage>(new Random().Next().ToString());
            subscriber.Subscribe(HandleTextMessage);
            
            Console.WriteLine("Listening for messages. Press any key to exit.");
            
            var running = true;
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) =>
            {
              Console.WriteLine("Exiting...");
              running = false;
            };
            
            while (running)
            {
            }
        }
    }
}