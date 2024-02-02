using System.Runtime.CompilerServices;

namespace ExploradorCommitsApp.Models
{
    public interface ICExplorerCommitsService
    {

        //Metodos Obligatorios para el servicio
        public dynamic loadRepositories(string library);

        public dynamic quantityCommits(string owner, string repositoryName);

    }
}
