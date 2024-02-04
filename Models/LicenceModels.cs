namespace ExploradorCommitsApp.Models
{

    /// <summary>
    /// Modelo para Mappear Cada Licencia de Un Repositorio
    /// </summary>
    public class LicenceModels
    {
        public string key { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string spdx_id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string node_id { get; set; } = string.Empty;
    }
}
