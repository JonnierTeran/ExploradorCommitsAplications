using ExploradorCommitsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExploradorCommitsApp.Services
{
    public class CommitExplorerService
    {
        private readonly HttpClient _httpClient;

        public CommitExplorerService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("TuApp"); // Agrega un encabezado User-Agent con el valor "TuApp"
        }

        
        
        
        // Método para calcular commits por semana Segun el Dueño y Repositorio que se busque
        public async Task<IActionResult> CommitsPorSemana()
        {
            try
            {
                string apiUrl = "https://api.github.com/repos/JonnierTeran/Frontend-control-de-actividades/stats/participation";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa, lee el cuerpo de la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la cadena JSON en un objeto countCommitsModels
                    var responseObject = JsonConvert.DeserializeObject<countCommitsModels>(responseBody);

                    // Devuelve un OkObjectResult con el objeto deserializado
                    return new OkObjectResult(responseObject);
                }
                else
                {
                    // Si la solicitud no es exitosa, devuelve un ObjectResult con un mensaje de error y el código de estado
                    return new ObjectResult("Error al obtener datos desde GitHub")
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
            }
            catch (Exception ex)
            {
                // Si hay una excepción, devuelve un ObjectResult con un mensaje de error interno y el código de estado 500
                return new ObjectResult($"Error interno: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
