using FluentValidation;
using IdentityServerProductApp.Api.Dtos;

namespace IdentityServerProductApp.Api.Validators
{
    public class signUpDtoValidator : AbstractValidator<SignUpDto>
    {
        public signUpDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
