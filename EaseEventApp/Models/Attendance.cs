using System.ComponentModel.DataAnnotations;

namespace EaseEventApp.Models;

public class Attendance
{
    public Guid ID { get; } = Guid.NewGuid();

    [Required(ErrorMessage = "Event ID is required")]
    public Guid EventID { get; set; }

    [Required(ErrorMessage = "Attendee name is required")]
    public string AttendeeName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email format is invalid")]
    public string Email { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public DateTime? CheckInTime { get; set; }

    public bool IsPresent => CheckInTime.HasValue;
}
