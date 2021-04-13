using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAndPets.Core.Application.People.Dtos
{
    public class GenderGroupEnvelope
    {
        public string Gender { get; set; }
        public string[] Pets { get; set; }
    }
}
