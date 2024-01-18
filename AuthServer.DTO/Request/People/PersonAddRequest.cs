﻿using AuthServer.Data.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AuthServer.DTO.Request.People
{
    public class PersonAddRequest
    {
        public IFormFile personImageURL { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string password { get; set; } = string.Empty;

        public Person Map(PersonAddRequest person)
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
    public class PersonAddRequestValidator : AbstractValidator<PersonAddRequest>
    {
        public PersonAddRequestValidator()
        {
            RuleFor(x => x.name).NotEmpty().MinimumLength(1).MaximumLength(20).WithMessage("Hata Name !");
            RuleFor(x => x.surname).NotEmpty().MinimumLength(1).MaximumLength(20).WithMessage("Hata  Surname!");
            RuleFor(x => x.age).NotEmpty().WithMessage("Hata  Age!");
            RuleFor(x => x.password).NotEmpty().MinimumLength(5).MaximumLength(20).WithMessage("Hata  Password!");
        }
    }


}