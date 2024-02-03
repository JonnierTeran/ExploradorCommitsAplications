using ExploradorCommitsApp.Models;
using ExploradorCommitsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ExploradorCommitsApp.Controllers
{
    [ApiController]
    [Route("CommitExplorer")]
    public class CommitExplorerController : ControllerBase
    {
        private  CommitExplorerService _commitExplorerService;

        public CommitExplorerController(CommitExplorerService commitExplorerService)
        {
            _commitExplorerService = commitExplorerService;
        }


        [HttpGet("ObtenerDatosDesdeGithub")]
        public async Task<IActionResult> ObtenerDatosDesdeGithub()
        {
            var result = await _commitExplorerService.CommitsPorSemana();
            return result;
        }
    }
}
