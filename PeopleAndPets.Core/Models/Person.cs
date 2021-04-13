
namespace PeopleAndPets.Core.Interfaces.Services.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public long Age { get; set; }
        public Pet[] Pets { get; set; }
    }
}