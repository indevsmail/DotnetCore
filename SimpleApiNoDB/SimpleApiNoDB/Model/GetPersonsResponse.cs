using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiNoDB.Model
{
    public class GetPersonsResponse : ResponseBase
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
