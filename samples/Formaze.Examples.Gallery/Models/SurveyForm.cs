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
    [Required, Display(GroupName = "Subscription")]
    public string FullName { get; set; } = string.Empty;

    [Display(GroupName = "Subscription")]
    public Plan Plan { get; set; } = Plan.Free;

    [Range(1, 1000), Display(GroupName = "Subscription")]
    public int Seats { get; set; } = 1;

    [Display(GroupName = "Subscription")]
    public bool AcceptTerms { get; set; }

    [DataType(DataType.Date), Display(GroupName = "Subscription")]
    public DateOnly? StartDate { get; set; }
}
