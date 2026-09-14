namespace FleetFlow.Shared.Domain;

/// <summary>Marker for a domain event raised by an aggregate as a result of a business state change.</summary>
public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}
