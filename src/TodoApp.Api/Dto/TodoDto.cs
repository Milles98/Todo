using System.ComponentModel.DataAnnotations;

namespace TodoApp.Dto
{
    public class TodoDto : IValidatableObject
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        //To ensure desc doesn't only have whitespaces
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                yield return new ValidationResult(
                    "Description cannot be empty or only whitespaces!",
                    new[] { nameof(Description) });
            }
        }
    }
}
