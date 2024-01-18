using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer.Data.Entity
{
    [Table("Person")]
    public class Person : Base_Entity
    {
        public string PersonImageURL { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Password { get; set; } = string.Empty;

    }
}

