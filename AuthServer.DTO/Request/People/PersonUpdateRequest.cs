using AuthServer.Data.Entity;
using AuthServer.DTO.Request.People;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AuthServer.DTO.Request.People
{
    
    public class PersonUpdateRequest
    {
        public int id { get; set; }
        public IFormFile personImageURL { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string password { get; set; } = string.Empty;

        public  Person Map(PersonUpdateRequest person)
        {
            Person newPerson = new Person()
            {
                Name = person.name,
                Surname = person.surname,
                Age = person.age,
                Password = person.password,
            };
            return newPerson;
        }
    }
    public class PersonUpdateRequestValidator : AbstractValidator<PersonUpdateRequest>
    {
        public PersonUpdateRequestValidator()
        {
            RuleFor(x => x.name).NotEmpty().MinimumLength(1).MaximumLength(20).WithMessage("Hata Name !");
            RuleFor(x => x.surname).NotEmpty().MinimumLength(1).MaximumLength(20).WithMessage("Hata  Surname!");
            RuleFor(x => x.age).NotEmpty().WithMessage("Hata  Age!");
            RuleFor(x => x.password).NotEmpty().MinimumLength(5).MaximumLength(20).WithMessage("Hata  Password!");
        }
    }


}
