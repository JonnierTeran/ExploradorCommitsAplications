namespace ExploradorCommitsApp.Models
{
    public class RepositoryModels
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<ItemModels> items { get; set; } = new List<ItemModels>();
    }
}
