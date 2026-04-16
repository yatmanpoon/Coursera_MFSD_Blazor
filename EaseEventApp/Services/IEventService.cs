using EaseEventApp.Models;

namespace EaseEventApp.Services;

/// <summary>
/// Defines the contract for event management operations.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Gets the list of all events.
    /// </summary>
    List<EventInfo> Events { get; }

    /// <summary>
    /// Retrieves an event by its ID.
    /// </summary>
    EventInfo? GetEventById(Guid eventId);
}
