using FluentValidation;
using System;
using TraingAppBackEnd.ViewModels;

namespace Api.ViewModels.NewFolder
{
    public class NewTraningReqestValidator : AbstractValidator<NewTrainingRequest>
    {
        public NewTraningReqestValidator()
        {
            RuleFor(x => x.RunnerId).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(x => x.TimeToDo).NotEmpty().NotNull().NotEqual(DateTime.MinValue);
            RuleFor(x => x.Details).NotEmpty().NotNull();
        }
    }
}
