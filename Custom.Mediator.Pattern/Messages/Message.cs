using System.ComponentModel.DataAnnotations;

namespace Custom.Mediator.Pattern.Infrastucture.Messages
{
    public abstract class Message
    {
        public Guid Id { get; set; }
    }
}