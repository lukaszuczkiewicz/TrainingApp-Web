using FluentValidation;

namespace Application.Coach.Commands
{
    public class CreateRunnerCommandValidator : AbstractValidator<CreateRunnerCommand>
    {
        public CreateRunnerCommandValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
