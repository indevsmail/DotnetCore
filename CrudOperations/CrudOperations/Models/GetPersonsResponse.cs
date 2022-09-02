﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Models
{
    public class GetPersonsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<Person> Persons { get; set; }
    }
}
