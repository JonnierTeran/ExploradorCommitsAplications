using Microsoft.AspNetCore.Mvc;

namespace ExploradorCommitsApp.Services.Interfaces
{
    public interface IComitExplorerService
    {
        Task<IActionResult> CommitsPorSemana(string library);
    }
}
