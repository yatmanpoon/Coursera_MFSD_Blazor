using System.ComponentModel.DataAnnotations;

namespace EaseEventApp.Models;

public class EventInfo
{
    public Guid ID { get; } = Guid.NewGuid();

    [Required(ErrorMessage = "Event name is required")]
    public string EventName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event date is required")]
    public DateTime EventDate { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; } = string.Empty;
}