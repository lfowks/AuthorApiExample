namespace MyApi.RequestObjects
{
    public class BookVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
        //Relacion
        public int AuthorId { get; set; }
    }
}
