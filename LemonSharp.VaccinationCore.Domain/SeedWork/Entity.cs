using MediatR;

namespace LemonSharp.VaccinationCore.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        private List<INotification>? _domainEvents;
        public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

        public bool IsTransient()
        {
            return Id == default;
        }
        
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
