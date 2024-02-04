namespace ExploradorCommitsApp.Models
{
    public class ResponseCommitUnit
    {
        /// <summary>
        /// Propiedad Para el manejo de errores
        /// </summary>
        public string MessageError { get; set; }

        /// <summary>
        /// Propiedad para almacenar los Commits Semanales por cada Repositorio
        /// </summary>
        public countCommitsModels Data { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public ResponseCommitUnit() 
        { 
            this.MessageError = string.Empty;
            this.Data = new countCommitsModels();
        }
    }
}
