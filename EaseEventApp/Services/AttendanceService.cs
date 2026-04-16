using EaseEventApp.Models;

namespace EaseEventApp.Services;

/// <summary>
/// Manages attendance tracking for events.
/// </summary>
public class AttendanceService : IAttendanceService
{
    private Dictionary<Guid, List<Attendance>> AttendanceRegistry { get; set; } = new();
    private readonly IEventService _eventService;

    public AttendanceService(IEventService eventService)
    {
        _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));

        // Initialize with sample attendance data using actual event IDs from EventService
        if (_eventService.Events.Count >= 2)
        {
            var springCharityRunEventId = _eventService.Events[0].ID;
            var techMeetupEventId = _eventService.Events[1].ID;

            AttendanceRegistry[springCharityRunEventId] = new List<Attendance>
            {
                new Attendance { EventID = springCharityRunEventId, AttendeeName = "John Smith", Email = "john@example.com", CheckInTime = DateTime.Now },
                new Attendance { EventID = springCharityRunEventId, AttendeeName = "Sarah Johnson", Email = "sarah@example.com", CheckInTime = null },
                new Attendance { EventID = springCharityRunEventId, AttendeeName = "Mike Brown", Email = "mike@example.com", CheckInTime = DateTime.Now }
            };

            AttendanceRegistry[techMeetupEventId] = new List<Attendance>
            {
                new Attendance { EventID = techMeetupEventId, AttendeeName = "Alice Chen", Email = "alice@example.com", CheckInTime = null },
                new Attendance { EventID = techMeetupEventId, AttendeeName = "Bob Wilson", Email = "bob@example.com", CheckInTime = DateTime.Now }
            };
        }
    }

    /// <summary>
    /// Register an attendee for an event
    /// </summary>
    public void RegisterAttendee(Guid eventId, Attendance attendance)
    {
        if (attendance == null)
            throw new ArgumentNullException(nameof(attendance));

        if (string.IsNullOrWhiteSpace(attendance.AttendeeName))
            throw new ArgumentException("Attendee name cannot be empty.", nameof(attendance));

        if (string.IsNullOrWhiteSpace(attendance.Email))
            throw new ArgumentException("Email cannot be empty.", nameof(attendance));

        // Validate that the event exists
        if (!_eventService.Events.Any(e => e.ID == eventId))
        {
            throw new InvalidOperationException($"Event with ID {eventId} does not exist.");
        }

        if (!AttendanceRegistry.ContainsKey(eventId))
        {
            AttendanceRegistry[eventId] = new List<Attendance>();
        }

        // Check if attendee is already registered (prevent duplicates by email)
        if (!AttendanceRegistry[eventId].Any(a => a.Email == attendance.Email))
        {
            AttendanceRegistry[eventId].Add(attendance);
        }
    }

    /// <summary>
    /// Get all attendees for an event
    /// </summary>
    public List<Attendance> GetEventAttendees(Guid eventId)
    {
        if (AttendanceRegistry.ContainsKey(eventId))
        {
            return AttendanceRegistry[eventId];
        }
        return new List<Attendance>();
    }

    /// <summary>
    /// Check in an attendee (mark as present)
    /// </summary>
    public void CheckInAttendee(Guid eventId, Guid attendanceId)
    {
        if (AttendanceRegistry.ContainsKey(eventId))
        {
            var attendance = AttendanceRegistry[eventId].FirstOrDefault(a => a.ID == attendanceId);
            if (attendance != null && !attendance.CheckInTime.HasValue)
            {
                attendance.CheckInTime = DateTime.Now;
            }
        }
    }

    /// <summary>
    /// Check out an attendee (mark as absent)
    /// </summary>
    public void CheckOutAttendee(Guid eventId, Guid attendanceId)
    {
        if (AttendanceRegistry.ContainsKey(eventId))
        {
            var attendance = AttendanceRegistry[eventId].FirstOrDefault(a => a.ID == attendanceId);
            if (attendance != null)
            {
                attendance.CheckInTime = null;
            }
        }
    }

    /// <summary>
    /// Get attendance statistics for an event
    /// </summary>
    public (int Total, int Present, int Absent) GetAttendanceStats(Guid eventId)
    {
        var attendees = GetEventAttendees(eventId);
        int total = attendees.Count;
        int present = attendees.Count(a => a.IsPresent);
        int absent = total - present;

        return (total, present, absent);
    }

    /// <summary>
    /// Remove an attendee from an event
    /// </summary>
    public void RemoveAttendee(Guid eventId, Guid attendanceId)
    {
        if (AttendanceRegistry.ContainsKey(eventId))
        {
            var attendance = AttendanceRegistry[eventId].FirstOrDefault(a => a.ID == attendanceId);
            if (attendance != null)
            {
                AttendanceRegistry[eventId].Remove(attendance);
            }
        }
    }
}
