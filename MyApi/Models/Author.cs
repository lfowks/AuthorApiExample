namespace MyApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        //Relaciones
        public List<Book> books { get; set; }
    }
}
