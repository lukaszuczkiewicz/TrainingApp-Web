using FluentValidation;

namespace Application.Coach.Commands
{
    public class UpdateRunnerCommandValidator : AbstractValidator<UpdateRunnerCommand>
    {
        public UpdateRunnerCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }
    }
}