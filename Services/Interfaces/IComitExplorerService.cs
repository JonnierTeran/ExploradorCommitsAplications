using ExploradorCommitsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploradorCommitsApp.Services.Interfaces
{

    /// <summary>
    /// Metodo que exponemos al Controlador
    /// </summary>
    public interface IComitExplorerService
    {
        Task<IActionResult> CommitsPorSemana(RequestCommits request);
    }
}
