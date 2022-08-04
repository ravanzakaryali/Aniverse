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
                .NotEmpty()
                    .WithMessage("Not empty");
            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Not empty")
                .Equals("ConfirmPassword");
            RuleFor(r=>r.PasswordConfirm)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Not empty")
                .Equals("Password");
            RuleFor(r=>r.Firtname)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Not empty")
                .MinimumLength(3)
                .MaximumLength(100);
            RuleFor(r => r.Lastname)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Not empty")
                .MinimumLength(3)
                .MaximumLength(100);


        }
    }
}
