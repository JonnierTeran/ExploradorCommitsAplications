namespace ExploradorCommitsApp.Models
{
    public class ResponseCommits
    {
        /// <summary>
        /// Nombre y autor del repositorio
        /// </summary>
        public string nameRepo { get; set; }

        /// <summary>
        /// Informacion del Repositorio Por semanas
        /// </summary>
        public countCommitsModels infoRepo { get; set; }

        /// <summary>
        /// Metodo constructor
        /// </summary>
        public ResponseCommits() {
            nameRepo= string.Empty;
            infoRepo = new countCommitsModels();
        }
    }
}
