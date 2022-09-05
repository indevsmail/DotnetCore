using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApiNoDB.Model;
using SimpleApiNoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiNoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        [Route("GetPersons")]
        public IActionResult GetPersons()
        {
            GetPersonsResponse response = null;
            try
            {
                response = _personRepository.GetPersons();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }
        [HttpPost]
        [Route("CreatePerson")]
        public IActionResult CreatePerson(CreatePersonRequest request)
        {
            CreatePersonResponse response = null;
            try
            {
                response = _personRepository.CreatePerson(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }
    }
}
