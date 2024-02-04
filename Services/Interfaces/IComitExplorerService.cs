using ExploradorCommitsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploradorCommitsApp.Services.Interfaces
{
    public interface IComitExplorerService
    {
        Task<IActionResult> CommitsPorSemana(RequestCommits request);
    }
}
