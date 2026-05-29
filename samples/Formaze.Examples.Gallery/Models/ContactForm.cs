using System.ComponentModel.DataAnnotations;

namespace Formaze.Examples.Gallery.Models;

public class ContactForm
{
    [Required, Display(GroupName = "Contact")]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, Display(GroupName = "Contact")]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.MultilineText), Display(GroupName = "Contact")]
    public string Message { get; set; } = string.Empty;
}
