namespace ExploradorCommitsApp.Models
{
    public class ResponseCommits
    {
        public ResponseCommits() {
            nameRepo= string.Empty;
            infoRepo = new countCommitsModels();
            likes = 0;
        }
        /// <summary>
        /// Nombre y autor del repositorio
        /// </summary>
        public string nameRepo { get; set; }
        public int likes { get; set; }
        public countCommitsModels infoRepo { get; set; }

    }
}
