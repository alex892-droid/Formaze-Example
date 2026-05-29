using System.ComponentModel.DataAnnotations;

namespace Formaze.Examples.Gallery.Models;

public enum Plan
{
    Free,
    Pro,
    Enterprise
}

public class SurveyForm
{
    [Required]
    public string FullName { get; set; } = string.Empty;

    public Plan Plan { get; set; } = Plan.Free;

    [Range(1, 1000)]
    public int Seats { get; set; } = 1;

    public bool AcceptTerms { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? StartDate { get; set; }
}
