namespace MyApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relaciones
        public List<Course> courses { get; set; }

    }
}
