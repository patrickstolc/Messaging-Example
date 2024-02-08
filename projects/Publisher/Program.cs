using Publisher.Publisher;
using Messages;
using ClientID;

namespace Publisher
{
  class Program
  {        
    static void Main(string[] args)
    {
      // Create Publisher and connect to the message broker
      var clientId = ClientId.GetClientId();
      var publisher = PublisherFactory.CreateEasyNetQsPublisher<TextMessage>(
        clientId
      );
      publisher.Connect();
      
      // Publish user input
      var input = "";
      Console.WriteLine("Enter a message to publish. Type 'exit' to quit.");
      
      while (input != "exit")
      {
        input = Console.ReadLine();
        if(input == null)
          continue;
        
        var message = new TextMessage { Text = input };
        publisher.Publish(message);
      }
      
    }
  }
}