using FluentValidation;
using TodoApp.Dto;

namespace TodoApp.Validation
{
    public class TodoPatchDtoValidator : AbstractValidator<TodoPatchDto>
    {
        public TodoPatchDtoValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Description is not null || x.IsCompleted is not null)
                .WithMessage("At least one field must be provided");

            When(x => x.Description is not null, () =>
            {
                RuleFor(x => x.Description!)
                .NotEmpty()
                .Must(s => !string.IsNullOrWhiteSpace(s))
                .WithMessage("'Description' must not be empty or whitespace")
                .MaximumLength(200);
            });
        }
    }
}
