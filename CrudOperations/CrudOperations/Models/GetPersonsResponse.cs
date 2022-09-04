using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Models
{
    public class GetPersonsResponse : ResponseBase
    {
        public List<Person> Persons { get; set; }
    }
}
