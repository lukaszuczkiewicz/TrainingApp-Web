using FluentValidation;

namespace Api.ViewModels.Validators
{
    public class CreateRunnerViewModelValidator : AbstractValidator<CreateRunnerViewModel>
    {
        public CreateRunnerViewModelValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(c => c.LastName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(c => c.Email).NotEmpty().NotNull().MinimumLength(3).Must(x => x.Contains('@'));
        }
    }
}
