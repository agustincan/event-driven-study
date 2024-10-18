namespace Custom.Mediator.Pattern.Exceptions
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(string message) : base(message)
        {
        }
    }
}