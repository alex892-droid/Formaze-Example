using System.ComponentModel.DataAnnotations;

namespace Formaze.Examples.Gallery.Models;

public class AllFieldsForm
{
    [Required, Display(GroupName = "Details")]
    public string Name { get; set; } = string.Empty;

    [EmailAddress, Display(GroupName = "Details")]
    public string Email { get; set; } = string.Empty;

    [Url, Display(GroupName = "Details")]
    public string Website { get; set; } = string.Empty;

    [DataType(DataType.MultilineText), Display(GroupName = "Details")]
    public string Bio { get; set; } = string.Empty;

    [Range(1, 100), Display(GroupName = "Details")]
    public int Quantity { get; set; } = 1;

    [Display(GroupName = "Details")]
    public decimal Price { get; set; }

    [Display(GroupName = "Details")]
    public bool Subscribe { get; set; }

    [Display(GroupName = "Details")]
    public Plan Plan { get; set; } = Plan.Free;

    [Display(GroupName = "Details")]
    public DateTime? Appointment { get; set; }

    [Display(GroupName = "Details")]
    public DateOnly? BirthDate { get; set; }

    [Display(GroupName = "Details")]
    public TimeSpan? PreferredTime { get; set; }
}
