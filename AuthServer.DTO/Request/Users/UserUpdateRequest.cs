using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AuthServer.DTO.Request.Users
{
    public class UserUpdateRequest
    {
        public long id { get; set; }       
        public IFormFile userImageURL { get; set; }
        public string? tckn { get; set; }
        public string? name { get; set; } 
        public string? surname { get; set; }
        public int age { get; set; }
        public string? userName { get; set; } 
        public string? email { get; set; } 
        public string? phoneNumber { get; set; }
        public string? password { get; set; }

    }
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.id)
                .NotNull().NotEmpty().WithMessage("Kullanıcı adı gereklidir.");
            RuleFor(x => x.tckn)
              .NotNull().NotEmpty().WithMessage("TCKN gereklidir.")
              .MinimumLength(11).WithMessage("TCKN 11 karakterden az olmamalıdır.")
              .MaximumLength(12).WithMessage("TCKN 12 karakteri geçmemelidir.");
            RuleFor(x => x.userName)
                .NotNull().NotEmpty().WithMessage("Kullanıcı adı gereklidir.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakteri geçmemelidir.");
            RuleFor(x => x.email)
                .NotNull().NotEmpty().WithMessage("E-posta gereklidir.")
                .MaximumLength(50).WithMessage("E-posta 50 karakteri geçmemelidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta gereklidir.");
            RuleFor(x => x.phoneNumber)
                .NotNull().NotEmpty().WithMessage("Telefon numarası gereklidir.")
                .MinimumLength(10).WithMessage("Telefon numarası 10 karakterden az olmamalıdır.")
                .MaximumLength(11).WithMessage("Telefon numarası 11 karakteri geçmemelidir.");
            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
            RuleFor(x => x.name)
                .NotEmpty().MinimumLength(3).WithMessage("Isminiz 3 karakterden az olmamalıdır")
                .MaximumLength(20).WithMessage("Hata Name !");
            RuleFor(x => x.surname)
                .NotEmpty().MinimumLength(1).MaximumLength(20).WithMessage("Hata  Surname!");
            RuleFor(x => x.age)
                .NotEmpty().WithMessage("Hata  Age!");
            RuleFor(x => x.password)
                .NotEmpty().MinimumLength(5).MaximumLength(20).WithMessage("Hata  Password!");
        }
    }
}

