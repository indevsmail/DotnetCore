using CrudOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Services
{
    public interface IPersonService
    {
        public Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request);
        public Task<GetPersonsResponse> GetPersons();
        public Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request);
        public Task<DeletePersonResponse> DeletePerson(DeletePesronRequest request);
    }
}
