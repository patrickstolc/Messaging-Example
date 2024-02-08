using MessageClient.Factory;

namespace Publisher.Publisher;

public static class PublisherFactory
{
  public static Publisher<TMessage> CreateEasyNetQsPublisher<TMessage>(string publisherId)
  {
    var easyNetQFactory = new EasyNetQFactory();
    var messageClient = easyNetQFactory.CreateTopicMessageClient<TMessage>(publisherId, "memes");
    return new Publisher<TMessage>(
      messageClient
    );
  }
}