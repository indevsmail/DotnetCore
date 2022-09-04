using CrudOperations.Models;
using CrudOperations.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [Route("CreatePerson")]
        public async Task<IActionResult> CreatePerson(CreatePersonRequest request)
        {
            CreatePersonResponse response = null;

            try
            {
                response = await _personService.CreatePerson(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }

        [HttpGet]
        [Route("GetPersons")]
        public async Task<IActionResult> GetPersons()
        {
            GetPersonsResponse response = null;
            try
            {
                response = await _personService.GetPersons();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(UpdatePersonRequest request)
        {
            UpdatePersonResponse response = null;
            try
            {
                response = await _personService.UpdatePerson(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("DeletePerson")]
        public async Task<IActionResult> DeletePerson(DeletePesronRequest request)
        {
            DeletePersonResponse response = null;
            try
            {
                response = await _personService.DeletePerson(request);
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
