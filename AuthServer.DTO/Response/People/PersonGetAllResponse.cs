using AuthServer.Data.Entity;

namespace AuthServer.DTO.Response.People
{
    public class PersonGetAllResponse
    {
        public long id { get; set; }
        public string personImageURL { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string password { get; set; } = string.Empty;

        public List<PersonGetAllResponse> Map(List<Person> people)
        {
            List<PersonGetAllResponse> response = new List<PersonGetAllResponse>();
            foreach (Person person in people)
            {
                PersonGetAllResponse personGetAll = new PersonGetAllResponse()
                {
                    id = person.Id,
                    name = person.Name,
                    age = person.Age,
                    password = person.Password,
                    surname = person.Surname,
                    personImageURL = person.PersonImageURL,
                };
                response.Add(personGetAll);
            }
            return response;

        }
    }
}
