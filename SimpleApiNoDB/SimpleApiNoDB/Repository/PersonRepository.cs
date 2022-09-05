using SimpleApiNoDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiNoDB.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> persons = new List<Person>()
        {
            new Person(){UserId=1,Name="Mark", Email="mark@gmail.com", Age=24},
            new Person(){UserId=2,Name="Sam", Email="sam@gmail.com", Age=34},
            new Person(){UserId=3,Name="Harit", Email="harit@gmail.com", Age=29},
            new Person(){UserId=4,Name="Dev", Email="dev@gmail.com", Age=35}
        };

        public CreatePersonResponse CreatePerson(CreatePersonRequest request)
        {
            CreatePersonResponse response = new CreatePersonResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                persons.Add(request.PersonDetail);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public GetPersonsResponse GetPersons()
        {
            GetPersonsResponse response = new GetPersonsResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                response.Persons = persons;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; 
            }
            return response;
        }
    }
}
