using MessageClient.Factory;

namespace Subscriber.Subscriber;

public static class SubscriberFactory
{
    public static Subscriber<TMessage> CreateEasyNetQSubscriber<TMessage>(string clientId)
    {
        var easyNetQFactory = new EasyNetQFactory();
        var messageClient = easyNetQFactory.CreateTopicMessageClient<TMessage>(clientId, "memes");
        return new Subscriber<TMessage>(
            messageClient
        );
    }
}