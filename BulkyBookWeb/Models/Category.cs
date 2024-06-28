using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category : IValidatableObject
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage="Display Order must be between 1 and 100 only.")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.Equals(Name, DisplayOrder.ToString()))
        {
             yield return new ValidationResult("Name and Display Order cannot be same.", new[] { nameof(Name), nameof(DisplayOrder) });
        }
    }
}
