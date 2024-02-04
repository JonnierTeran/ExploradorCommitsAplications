using ExploradorCommitsApp.Models;
using ExploradorCommitsApp.Services;
using ExploradorCommitsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ExploradorCommitsApp.Controllers
{
    [ApiController]
    [Route("CommitExplorer")]
    public class CommitExplorerController : ControllerBase
    {
        readonly  IComitExplorerService  _commitExplorerService;

        public CommitExplorerController()
        {
            _commitExplorerService = new CommitExplorerService();
        }


        [HttpPost("ObtenerDatosDesdeGithub")]
        public async Task<IActionResult> ObtenerDatosDesdeGithub(RequestCommits request)
        {
            var result = await _commitExplorerService.CommitsPorSemana(request);
            return result;
        }
    }
}
