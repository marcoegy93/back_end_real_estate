using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using Backend_Projet_BDD.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Backend_Projet_BDD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonneController : ControllerBase
    {

       IPersonneService _personneService;

        public PersonneController(IPersonneService personneService)
        {
            this._personneService = personneService;
        }

        [HttpGet("getAllPersonne")]
        public List<Personne> getAllLogement()
        {
            return this._personneService.getAllPersonne();
        }

    }
}
