namespace ExploradorCommitsApp.Models
{
    /// <summary>
    /// Modelo Para Mappear La informacion de Un Repositorio desde La API de GitHub
    /// </summary>
    public class RepositoryModels
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<ItemModels> items { get; set; } 

        /// <summary>
        /// Constructor de Objetos
        /// </summary>
        public RepositoryModels() 
        { 
            this.total_count = int.MaxValue; 
            this.incomplete_results = false;
            this.items = new List<ItemModels>();
        }
    }
}
