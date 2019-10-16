using FluentValidation;

namespace Application.IdentityAndAccess.Services
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(p => p.Login).NotNull().NotEmpty();
            RuleFor(p => p.Password).NotNull().NotEmpty();
            RuleFor(p => p.Code).NotNull().Length(6);
        }
    }
}
