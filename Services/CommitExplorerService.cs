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


        // Método para consultar los repositorios por libreria
        public async Task<RepositoryModels> CommitsPorLibreria(string library)
        {


            try
            {
                string apiUrl = $"https://api.github.com/search/repositories?q={library}&per_page=2";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa, lee el cuerpo de la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la cadena JSON en un objeto countCommitsModels
                    var responseObject = JsonConvert.DeserializeObject<RepositoryModels>(responseBody);


                    // Devuelve un OkObjectResult con el objeto deserializado
                    return responseObject;
                }
                else
                {
                    // Si la solicitud no es exitosa, devuelve un ObjectResult con un mensaje de error y el código de estado
                    //return new ObjectResult("Error al obtener datos desde GitHub")
                    //{
                    //    StatusCode = (int)response.StatusCode
                    //};

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

        // Método para calcular commits por semana Segun el Dueño y Repositorio que se busque
        public async Task<IActionResult> CommitsPorSemana(string library)
        {
            List<ResponseCommits> responseData = new List<ResponseCommits>();
            var Repo = await this.CommitsPorLibreria(library);

            if (Repo != null)
            {
                if (Repo.items.Count > 0)
                {
                    for (int i = 0; i < Repo.items.Count; i++)
                    {
                        ResponseCommits auxData = new ResponseCommits();
                        var full_name = Repo.items[i].full_name;
                        var da = await this.CommitsPorSemana2(full_name);
                        auxData.infoRepo= da.Data;
                        auxData.nameRepo = full_name;
                        responseData.Add(auxData);
                    }
                
                }
            }

            return new OkObjectResult(responseData);


        }


        private  async Task<ResponseCommitUnit> CommitsPorSemana2(string fullName)
        {
            var response2 = new ResponseCommitUnit();
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

                    // Devuelve un OkObjectResult con el objeto deserializado
                    response2.Data = responseObject;
                    return response2;
                }
                else
                {
                    response2.MessageError = "No hay data para mostrar";
                    response2.Data = null;
                    return response2;

                }
            }
            catch (Exception ex)
            {

                response2.MessageError = ex.Message;
                response2.Data = null;
                return response2;

            }


        }
    }
}
