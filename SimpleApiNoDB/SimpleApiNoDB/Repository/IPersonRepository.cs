using SimpleApiNoDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiNoDB.Repository
{
    public interface IPersonRepository
    {
        public GetPersonsResponse GetPersons();
        public CreatePersonResponse CreatePerson(CreatePersonRequest request);
    }
}
