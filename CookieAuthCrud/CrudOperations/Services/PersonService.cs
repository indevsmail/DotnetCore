using CookiAuthCrud.Models;
using CookiAuthCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Services
{
    public class PersonService :IPersonService
    {
        public readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request)
        {
            return await _personRepository.CreatePerson(request);
        }
        public async Task<GetPersonsResponse> GetPersons()
        {
            return await _personRepository.GetPersons();
        }
        public async Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request)
        {
            return await _personRepository.UpdatePerson(request);
        }
        public async Task<DeletePersonResponse> DeletePerson(DeletePesronRequest request)
        {
            return await _personRepository.DeletePerson(request);
        }
    }
}
