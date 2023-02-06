using Backend_Projet_BDD.IService;
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
        public string getAllLogement()
        {
            return this._logementService.getAllLogement();
        }
      

    }
}
