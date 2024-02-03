namespace ExploradorCommitsApp.Models
{
    public class OwnerModels
    {
        public string login { get; set; } = string.Empty;
        public int id { get; set; } = int.MaxValue;
        public string node_id { get; set; } = string.Empty;
        public string avatar_url { get; set; } = string.Empty;
        public string gravatar_id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string html_url { get; set; } = string.Empty;
        public string followers_url { get; set; } = string.Empty;
        public string following_url { get; set; } = string.Empty;
        public string gists_url { get; set; } = string.Empty;
        public string starred_url { get; set; } = string.Empty;
        public string subscriptions_url { get; set; } = string.Empty;
        public string organizations_url { get; set; } = string.Empty;
        public string repos_url { get; set; } = string.Empty;
        public string events_url { get; set; } = string.Empty;
        public string received_events_url { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public bool site_admin { get; set; }
    }
}
