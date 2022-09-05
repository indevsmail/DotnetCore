using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Models
{
    public class CreatePersonRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public long Phone { get; set; }
    }
}
