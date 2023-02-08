using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using Backend_Projet_BDD.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Projet_BDD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogementController : ControllerBase
    {
        ILogementService _logementService;

        public LogementController(ILogementService metroService)
        {
            this._logementService = metroService;
        }

        [HttpGet("getAllLogement")]
        public List<Logement> getAllLogement()
        {
            return this._logementService.getAllLogement();
        }

        [HttpGet("getLogementByWord/{word}")]
        public List<Logement> getLogementByWord(String word)
        {
            return this._logementService.getLogementByWord(word);
        }

        [HttpPost("getLogementByCriteria")]
        public List<Logement> getLogementByCriteria(Criteria listcriteria)
        {
            return this._logementService.getLogementByCriteria(listcriteria);
        }


    }
}
