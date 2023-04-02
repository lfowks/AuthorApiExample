using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;
using MyApi.RequestObjects;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public StudentsController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            if (_context.Author == null)
            {
                return NotFound();
            }

            List<Student> listaStudents = await _context.Student.Include("courses").ToListAsync();

            //foreach (Student item in listaStudents)
            //{
            //    foreach (Course course in item.courses)
            //    {
            //        course.students = null;
            //    }
            //} // Arreglar esto

            return listaStudents;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentVm studentRequest)
        {

            //Student newStudent = new Student();
            //newStudent.Name = "Student 1";

            //newStudent.courses = new List<Course>
            //{
            //    new Course { Name = "Course 1"},
            //    new Course { Name = "Course 2"},
            //};

            //_context.Student.Add(newStudent);

            Student student = new Student();
            student.Name = studentRequest.Name;

            student.courses = new List<Course>();

            foreach (var itemRequest in studentRequest.Courses)
            {
                Course newCourse = new Course();
                newCourse.Name = itemRequest.Name;
                student.courses.Add(newCourse);
            }


            _context.Student.Add(student);
            _context.SaveChanges();


            return CreatedAtAction("PostStudent", new { id = student.Id });
        }

    }
}
