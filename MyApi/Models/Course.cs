namespace MyApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> students { get; set; }
    }
}
