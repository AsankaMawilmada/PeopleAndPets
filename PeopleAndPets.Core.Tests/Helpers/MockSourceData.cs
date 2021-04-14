using PeopleAndPets.Core.Interfaces.Services.Models;
using System.Collections.Generic;

namespace PeopleAndPets.Core.Tests.Helpers
{
    public static class MockSourceData
    {
        public static List<Person> People = new List<Person>
        {
            new Person
            {
                Name = "Bob",
                Age = 23,
                Gender ="Male",
                Pets = new Pet[]
                {
                    new Pet
                    {
                        Name = "Garfield",
                        Type ="Cat"
                    },
                    new Pet
                    {
                        Name = "Fido",
                        Type= "Dog"
                    }
                }
            },
            new Person
            {
                Name = "Jennifer",
                Gender = "Female",
                Age = 18,
                Pets = new Pet[]
                {
                    new Pet
                    {
                        Name = "Garfield",
                        Type = "Cat"
                    }
                }
            },
            new Person
            {
                Name = "Steve",
                Gender = "Male",
                Age = 45,
                Pets = null
            },
            new Person
            {
                Name = "Fred",
                Gender = "Male",
                Age = 40,
                Pets = new Pet[]
                {
                    new Pet
                    {
                        Name = "Tom",
                        Type = "Cat"
                    },
                    new Pet
                    {
                        Name = "Max",
                        Type = "Cat"
                    },
                    new Pet
                    {
                        Name = "Sam",
                        Type = "Dog"
                    },
                    new Pet
                    {
                        Name = "Jim",
                        Type = "Cat"
                    }
                }
            },
            new Person
            {
                Name = "Samantha",
                Gender = "Female",
                Age = 40,
                Pets = new Pet[]
                {
                    new Pet
                    {
                        Name = "Tabby",
                        Type = "Cat"
                    }
                }
            },
            new Person
            {
                Name = "Alice",
                Gender = "Female",
                Age = 64,
                Pets = new Pet[]
                {
                    new Pet
                    {
                        Name = "Simba",
                        Type = "Cat"
                    },
                    new Pet
                    {
                        Name = "Nemo",
                        Type = "Fish"
                    }
                }
            }
        };

    }
}
