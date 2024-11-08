using Custom.Mediator.Pattern.Events;

namespace Custom.Mediator.Pattern.Domain
{
    // Remember to say: Remember I've said that no update or delete operations are allow for event store. It should be Immutable / unchangable 
    public interface IEventStoreRepository
    {
        Task SaveAsync(EventModel @event);
        Task<List<EventModel>> FindAllAsync();
        Task<List<EventModel>> FindByAggregateId(Guid aggregateId);
    }
}