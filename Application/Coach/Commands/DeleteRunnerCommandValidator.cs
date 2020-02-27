using FluentValidation;

namespace Application.Coach.Commands
{
    class DeleteRunnerCommandValidator : AbstractValidator<DeleteRunnerCommand>
    {
        public DeleteRunnerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
