using FluentValidation;
using TodoApp.Application.Dto;

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
