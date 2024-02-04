namespace ExploradorCommitsApp.Models
{
    /// <summary>
    /// Modelo Necesario para recibir la Data
    /// </summary>
    public class RequestCommits
    {
       
        /// <summary>
        /// Libreria a consultar
        /// </summary>
        public string libreria {  get; set; }

        /// <summary>
        /// Cantidad de repositorios que se quieren ver
        /// </summary>
        public int CantidadRepo { get; set; }


        /// <summary>
        /// Metodo Constructor
        /// </summary>
        public RequestCommits()
        {
            this.libreria = String.Empty;
            this.CantidadRepo = int.MaxValue;
        }
    }
}
