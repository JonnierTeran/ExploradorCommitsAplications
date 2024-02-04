using ExploradorCommitsApp.Models;
using ExploradorCommitsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace ExploradorCommitsApp.Services
{
    public class CommitExplorerService : IComitExplorerService
    {
        private readonly HttpClient _httpClient;

        public CommitExplorerService()
        {
            _httpClient = new HttpClient();
           
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("TuApp"); // Agrega un encabezado User-Agent con el valor "TuApp"
        }

        
        
        #region Metodos publicos

        /// <summary>
        /// Método para calcular commits por semana Segun el Dueño y Repositorio que se busque
        /// </summary>
        /// <param name="data"> Libreria y Semanas</param>
        /// <returns> Lista de los commits</returns>
        public async Task<IActionResult> CommitsPorSemana(RequestCommits data)
        {
            List<ResponseCommits> responseData = new List<ResponseCommits>();
            var Repo = await this.CommitsPorLibreria(data);

            if (Repo != null)
            {
                if (Repo.items.Count > 0)
                {
                    for (int i = 0; i < Repo.items.Count; i++)
                    {
                        ResponseCommits auxData = new ResponseCommits();
                        var full_name = Repo.items[i].full_name;
                        var da = await this.CommitsPorSemana2(full_name);
                        auxData.infoRepo = da.Data;
                        auxData.nameRepo = full_name;
                        responseData.Add(auxData);
                    }

                }
            }

            return new OkObjectResult(responseData);


        }
        #endregion


        #region Métodos privados
        // Método para consultar los repositorios por libreria
        private async Task<RepositoryModels> CommitsPorLibreria(RequestCommits data)
        {


            try
            {
                string apiUrl = $"https://api.github.com/search/repositories?q={data.libreria}&per_page={data.CantidadRepo}";            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa, lee el cuerpo de la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la cadena JSON en un objeto countCommitsModels
                    var responseObject = JsonConvert.DeserializeObject<RepositoryModels>(responseBody);

                    //Valida que el Objeto no sea null
                    if (responseObject != null)
                    {
                        return responseObject; //Retorna el Objeto
                    }
                    else
                    {
                        return new RepositoryModels(); // Retorna un objeto vacido
                    }
                    
                }
                else
                {
                    

                    return new RepositoryModels();

                }
            }
            catch (Exception ex)
            {
                // Si hay una excepción, devuelve un ObjectResult con un mensaje de error interno y el código de estado 500
                return new RepositoryModels();

            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        private  async Task<ResponseCommitUnit> CommitsPorSemana2(string fullName)
        {
            var responseFinal = new ResponseCommitUnit();
            try
            {

                string apiUrl = "https://api.github.com/repos/" + fullName + "/stats/participation";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa, lee el cuerpo de la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la cadena JSON en un objeto countCommitsModels
                    var responseObject = JsonConvert.DeserializeObject<countCommitsModels>(responseBody);

                    // Devuelve un  con el objeto deserializado
                    responseFinal.Data = responseObject;
                    return responseFinal;
                }
                else
                {
                    responseFinal.MessageError = "No hay data para mostrar";
                    responseFinal.Data = null;
                    return responseFinal;

                }
            }
            catch (Exception ex)
            {

                responseFinal.MessageError = ex.Message;
                responseFinal.Data = null;
                return responseFinal;

            }


        }

        #endregion
    }
}
