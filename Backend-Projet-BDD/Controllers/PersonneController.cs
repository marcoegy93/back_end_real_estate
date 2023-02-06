using Backend_Projet_BDD.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Backend_Projet_BDD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonneController : ControllerBase
    {

       PersonneService _personneService;

        public PersonneController(PersonneService personneService)
        {
            this._personneService = personneService;
        }

        [HttpGet("getAllPersonne")]
        public string getAllLogement()
        {
            return "ok";
        }

    }
}
