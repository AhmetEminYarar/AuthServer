using FluentValidation;

namespace AuthServer.DTO.Request.Authentication
{
    public class AuthenticationRequest
    {
        public string? tckn { get; set; }
        public string? password { get; set; } 

    }
    public class AuthenticationLoginRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationLoginRequestValidator()
        {
            RuleFor(x => x.tckn)
                  .NotNull().NotEmpty().WithMessage("TCKN gereklidir.")
                  .MinimumLength(11).WithMessage("TCKN 11 karakterden az olmamalıdır.")
                  .MaximumLength(12).WithMessage("TCKN 12 karakteri geçmemelidir.");
            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
        }
    }
}
