using System.ComponentModel.DataAnnotations;

namespace Formaze.Examples.Gallery.Models;

public class AllFieldsForm
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Url]
    public string Website { get; set; } = string.Empty;

    [DataType(DataType.MultilineText)]
    public string Bio { get; set; } = string.Empty;

    [Range(1, 100)]
    public int Quantity { get; set; } = 1;

    public decimal Price { get; set; }

    public bool Subscribe { get; set; }

    public Plan Plan { get; set; } = Plan.Free;

    public DateTime? Appointment { get; set; }

    public DateOnly? BirthDate { get; set; }

    public TimeSpan? PreferredTime { get; set; }
}
