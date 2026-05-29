using System.ComponentModel.DataAnnotations;

namespace Formaze.Examples.CustomStore.Models;

public class ContactForm
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.MultilineText)]
    public string Message { get; set; } = string.Empty;
}
