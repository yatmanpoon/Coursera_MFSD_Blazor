using EaseEventApp.Models;

namespace EaseEventApp.Services;

/// <summary>
/// Defines the contract for attendance tracking operations.
/// </summary>
public interface IAttendanceService
{
    /// <summary>
    /// Registers an attendee for an event.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when event does not exist.</exception>
    void RegisterAttendee(Guid eventId, Attendance attendance);

    /// <summary>
    /// Gets all attendees for a specific event.
    /// </summary>
    List<Attendance> GetEventAttendees(Guid eventId);

    /// <summary>
    /// Marks an attendee as checked in to an event.
    /// </summary>
    void CheckInAttendee(Guid eventId, Guid attendanceId);

    /// <summary>
    /// Marks an attendee as checked out from an event.
    /// </summary>
    void CheckOutAttendee(Guid eventId, Guid attendanceId);

    /// <summary>
    /// Gets attendance statistics for an event.
    /// </summary>
    (int Total, int Present, int Absent) GetAttendanceStats(Guid eventId);

    /// <summary>
    /// Removes an attendee from an event.
    /// </summary>
    void RemoveAttendee(Guid eventId, Guid attendanceId);
}
