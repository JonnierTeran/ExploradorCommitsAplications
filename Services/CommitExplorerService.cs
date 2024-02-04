using ExploradorCommitsApp.Models;
using ExploradorCommitsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace ExploradorCommitsApp.Services
{
    public class CommitExplorerService : IComitExplorerService
    {
        /// <summary>
        /// Propiedad para de tipo httpClient como servicio para peticiones http
        /// </summary>
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
            //Se crea un Arrays de Objetos que retornara el metodo
            List<ResponseCommits> responseData = new List<ResponseCommits>();

            //Se Ejecuta el metodo asincrono y se obtienen los Repositorios que utilizan x tecnologia
            var Repo = await this.CommitsPorLibreria(data);

            //Validacion de la respuesta del metodo
            if (Repo != null)
            {
                if (Repo.items.Count > 0)  // Se Realiza un conteo de la propiedad Items que contiene la informacion de los repositorios
                {   
                    //Se recorren los Repositorios segun la propiedad Items
                    for (int i = 0; i < Repo.items.Count; i++)
                    {
                        
                        ResponseCommits auxData = new ResponseCommits(); // Variable auxiliar para agregar a la lista
                        var full_name = Repo.items[i].full_name; // Se Obtiene la propiedad full_name que contiene nombre/Repositorio para el Endpoint de github
                        var info = await this.CommitsSemanales(full_name); //Por medio de un metodo asincrono se consultan los comits por semana de x repositorio
                        auxData.infoRepo = info.Data;  // Se pasa la Data Obtenda (Cantidad de comits semanales) al objeto auxiliar
                        auxData.nameRepo = full_name; // Se pasa el nombre del Repositorio
                        responseData.Add(auxData); // Se agrega a la lista que se retornara como respuesta  
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
                //Consulta a la API De github por medio de este endpoint
                string apiUrl = $"https://api.github.com/search/repositories?q={data.libreria}&per_page={data.CantidadRepo}";         
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

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
        
        
        private  async Task<ResponseCommitUnit> CommitsSemanales(string fullName)
        {
            
            var responseFinal = new ResponseCommitUnit(); //Instancia para la respuesta

            try
            {
                //Endpoint Para Consultar Commits Semanales por cada Repositorio
                string apiUrl = "https://api.github.com/repos/" + fullName + "/stats/participation";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa, lee el cuerpo de la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la cadena JSON en un objeto countCommitsModels
                    var responseObject = JsonConvert.DeserializeObject<countCommitsModels>(responseBody);

                    // Devuelve un  con el objeto deserializado
                    if(responseObject != null)
                    {
                    responseFinal.Data = responseObject;
                    return responseFinal;

                    }
                    return responseFinal;
                }
                else
                {
                    //Manejo de Errores
                    responseFinal.MessageError = "No hay data para mostrar";
                    responseFinal.Data = null;
                    return responseFinal;

                }
            }
            catch (Exception ex)
            {
                //Manejo de Errores
                responseFinal.MessageError = ex.Message;
                responseFinal.Data = null;
                return responseFinal;

            }


        }

        #endregion
    }
}
