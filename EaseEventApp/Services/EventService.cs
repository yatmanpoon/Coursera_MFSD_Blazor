using EaseEventApp.Models;

namespace EaseEventApp.Services;

/// <summary>
/// Manages event data and operations.
/// </summary>
public class EventService : IEventService
{
    public List<EventInfo> Events { get; private set; } = new();

    public EventService()
    {
        // Initialize with sample data
        Events = new List<EventInfo>
        {
            new EventInfo { EventName = "Spring Charity Run", EventDate = DateTime.Today.AddDays(10), Location = "City Park" },
            new EventInfo { EventName = "Tech Meetup", EventDate = DateTime.Today.AddDays(20), Location = "Downtown Conference Center" },
            new EventInfo { EventName = "Summer Concert", EventDate = DateTime.Today.AddMonths(1), Location = "Riverfront Amphitheater" }
        };
    }

    /// <summary>
    /// Retrieves an event by its ID.
    /// </summary>
    public EventInfo? GetEventById(Guid eventId)
    {
        return Events.FirstOrDefault(e => e.ID == eventId);
    }
}