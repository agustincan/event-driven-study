namespace Custom.Mediator.Pattern.Consumers
{
    public interface IEventConsumer
    {
        void Consume(string topic);
    }
}