using Custom.Mediator.Pattern.Events;

namespace Custom.Mediator.Pattern.Producers
{
    public interface IEventProducer
    {
        Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent;
    }
}