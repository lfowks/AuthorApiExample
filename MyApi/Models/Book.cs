namespace MyApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        //Relaciones
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
