using Custom.Mediator.Pattern.Infrastucture.Commands;

namespace Custom.Mediator.Pattern.Infrastucture
{
    public interface ICommandDispatcher
    {
        void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand;
        Task SendAsync(BaseCommand command);
    }
}
