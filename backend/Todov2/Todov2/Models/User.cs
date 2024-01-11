using System.ComponentModel.DataAnnotations;

namespace Todov2.Models
{
    // typically use PascalCase for the properties
    public class User
    {
        // for the one to many, I annotate that this will be a fk elsewhere
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
    }
}
