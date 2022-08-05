using Aniverse.Application.DTOs.Auth;
using FluentValidation;

namespace Aniverse.Application.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Email)
                .EmailAddress()
                    .WithMessage("Please enter email")
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                .Equals("ConfirmPassword");
            RuleFor(r=>r.PasswordConfirm)
                .NotNull()
                .NotEmpty()
                .Equals("Password");
            RuleFor(r=>r.Firtname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
            RuleFor(r => r.Lastname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);


        }
    }
}
