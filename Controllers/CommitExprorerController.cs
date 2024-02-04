using ExploradorCommitsApp.Models;
using ExploradorCommitsApp.Services;
using ExploradorCommitsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace ExploradorCommitsApp.Controllers
{/// <summary>
/// Indicaciones de la Ruta del controlador
/// </summary>
    [ApiController]
    [Route("CommitExplorer")]
    public class CommitExplorerController : ControllerBase //Indicamos que es un controlador del API
    {
        //Servicio de Tipo Interface
        readonly  IComitExplorerService  _commitExplorerService;

        //Constructor para Injeccion del servicio
        public CommitExplorerController()
        {
            _commitExplorerService = new CommitExplorerService();
        }



        /// <summary>
        /// Metodo Post para recibir un Objeto Con la Libreria deseada y con la cantidad de Repositorios que quiere ver
        /// </summary>
        /// <param name="request"></param>
        /// <returns> Lista de Respuestas con Nombre del repositorio y Comits por semana</returns>
        [HttpPost("ObtenerDatosDesdeGithub")]
        public async Task<IActionResult> ObtenerDatosDesdeGithub(RequestCommits request)
        {
            //Llamado al servicio y a su metodo asincrono 
            var result = await _commitExplorerService.CommitsPorSemana(request);
            return result;
        }
    }
}
