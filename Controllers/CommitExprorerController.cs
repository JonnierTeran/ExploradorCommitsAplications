using Microsoft.AspNetCore.Mvc;

namespace ExploradorCommitsApp.Controllers
{

    [ApiController] //indica que es un controlador api
    [Route("CommitExplorer")] // Ruta del controlador
    public class CommitExprorerController : ControllerBase //Indicar que es un controlador
    {
        
        [HttpGet]
        [Route("Prueba")]
        public dynamic Ejemplo() 
        {
            return new 
            { 
                message = "Commit Explorer Aplications"
            };
        }
    }
}
