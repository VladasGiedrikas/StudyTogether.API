using Microsoft.AspNetCore.Mvc;
using StudyTogether.API.Models;
using StudyTogether.API.Services;
using System.Collections.Generic;

namespace StudyTogether.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsServices _main;

        public StudentsController(IStudentsServices main)
        {
            _main = main;
        }

        [HttpGet("", Name = "Students_GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return _main.GetAllStudents();
        }

        [HttpGet("studentId", Name = "Students_GetStudentById")]
        public ActionResult<Student> GetStudentById(int studentId)
        {
            return _main.GetStudentById(studentId);
        }

        [HttpGet("studentCheck", Name = "Students_GetStudentCheck")]
        public ActionResult<Student> GetStudentCheck(string studentName, string studetPassword)
        {
            return _main.GetStudentCheck(studentName, studetPassword);
        }

        [HttpPost("", Name = "Students_InsertStudent")]
        public ActionResult<bool> InsertStudent([FromBody] Student entry)
        {
            return _main.InsertStudent(entry);
        }


        [HttpPut("studentId", Name = "Students_UpdateStudent")]
        public ActionResult<bool> UpdateStudent(int studentId, [FromBody] Student entry)
        {
            return _main.UpdateStudent(studentId, entry);
        }

        [HttpDelete("studentId", Name = "Students_DeleteStudent")]
        public ActionResult<bool> DeleteStudent(int studentId)
        {
            return _main.DeleteStudent(studentId);
        }
    }
}
