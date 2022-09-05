using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Models
{
    public class GetPersonsResponse : ResponseBase
    {
        public List<Person> Persons { get; set; }
    }
}
