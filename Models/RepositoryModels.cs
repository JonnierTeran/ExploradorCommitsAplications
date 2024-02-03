namespace ExploradorCommitsApp.Models
{
    public class RepositoryModels
    {
        public int TotalCount { get; set; }
        public bool IncompleteResults { get; set; }
        public List<ItemModels> Items { get; set; }
    }
}
