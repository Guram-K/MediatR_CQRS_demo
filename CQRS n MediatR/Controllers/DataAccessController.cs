using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_n_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataAccessController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public DataAccessController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("GetPeople")]
        public async Task<IEnumerable<PersonModel>> GetPeople() => await _mediatR.Send(new GetPersonListQuery());

        [HttpGet]
        [Route("GetPerson")]
        public async Task<PersonModel> GetPeople(int id) => await _mediatR.Send(new GetPersonByIdQuery(id));

        [HttpPost]
        [Route("InsertPerson")]
        public async Task<PersonModel> InsertPerson(PersonModel person) => await _mediatR.Send(new InsertPersonCommand(person.FirstName, person.LastName));
    }
}
