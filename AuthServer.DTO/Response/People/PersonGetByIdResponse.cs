using AuthServer.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DTO.Response.People
{
    public class PersonGetByIdResponse
    {
        public int id { get; set; }
        public string personImageURL { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string password { get; set; } = string.Empty;
        public PersonGetByIdResponse Map(Person person)
        {
            this.id = person.Id;
            this.personImageURL = person.PersonImageURL;
            this.name = person.Name;
            this.surname = person.Surname;
            this.age = person.Age;
            this.password = person.Password;
           
            return this;
        }
    }
}
