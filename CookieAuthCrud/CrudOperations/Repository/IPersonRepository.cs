using CookiAuthCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Repository
{
    public interface IPersonRepository
    {
        public Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request);
        public Task<GetPersonsResponse> GetPersons();
        public Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request);
        public Task<DeletePersonResponse> DeletePerson(DeletePesronRequest request);

    }
}
