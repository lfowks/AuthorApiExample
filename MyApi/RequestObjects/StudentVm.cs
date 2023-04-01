namespace MyApi.RequestObjects
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CourseVm> Courses { get; set; }
    }

    public class CourseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
