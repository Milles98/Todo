using FluentValidation;
using TodoApp.Dto;

namespace TodoApp.Validation
{
    public class TodoDtoValidator : AbstractValidator<TodoDto>
    {
        public TodoDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        }
    }
}
