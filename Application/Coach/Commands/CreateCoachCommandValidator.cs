using FluentValidation;

namespace Application.Coach.Commands
{
    public class CreateCoachCommandValidator : AbstractValidator<CreateCoachCommand>
    {
        public CreateCoachCommandValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PreSharedKey).Length(12);
            RuleFor(x => x.Email).NotNull();
        }
    }
}
