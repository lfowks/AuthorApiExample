using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        //Relaciones
        public int AuthorId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }
    }
}
