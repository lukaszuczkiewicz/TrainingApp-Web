using FluentValidation;
using System;

namespace Application.Coach.Commands
{
    public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            RuleFor(x => x.RunnerId).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(x => x.TimeToDo).NotEmpty().NotNull().NotEqual(DateTime.MinValue); 
            RuleFor(x => x.Details).NotEmpty().NotNull();
        }
    }
}
