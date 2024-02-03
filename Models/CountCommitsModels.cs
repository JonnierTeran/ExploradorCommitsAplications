using Microsoft.AspNetCore.Mvc;

namespace ExploradorCommitsApp.Models
{
    public class countCommitsModels
    {
     
        /// <summary>
        /// ES: Todos las confirmaciones por semana 
        /// EN: Todos las confirmaciones por semana 
        /// </summary>
        public List<int>? All { get; set; }

        public List<int>? Owner { get; set; }

    }

}

