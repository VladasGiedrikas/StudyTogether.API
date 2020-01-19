using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudyTogether.API.Services
{
    public interface IStudentsServices
    {

        List<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        Student GetStudentCheck(string studentName, string studetPassword);
        bool InsertStudent(Student entry);
        bool UpdateStudent(int studentId, Student entry);
        bool DeleteStudent(int StudentId);
    }

    public class StudentsServices : IStudentsServices
    {
        private readonly StudyTogetherDbContext _context;
        public StudentsServices(StudyTogetherDbContext context)
        {
            _context = context;
        }
        #region GET

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {

            var entry = _context.Students.Where(x => x.StudentNumber == studentId).FirstOrDefault();
            return entry;
        }
        public Student GetStudentCheck(string studentName, string studetPassword)
        {
            return _context.Students.Where(x => x.StudentName == studentName && x.Password == studetPassword).FirstOrDefault();
        }
        #endregion

        #region POST
        public bool InsertStudent(Student entry)
        {                 
            _context.Students.Add(entry);
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region PUT
        public bool UpdateStudent(int studentId, Student entry)
        {
            var delete = _context.Students.FirstOrDefault(x => x.StudentNumber.Equals(studentId));
            _context.Students.Remove(delete);        
            _context.Students.Add(entry);
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region DELETE

        public bool DeleteStudent(int StudentId)
        {

            var delete = _context.Students.FirstOrDefault(x => x.StudentNumber.Equals(StudentId));
            _context.Students.Remove(delete);
            _context.SaveChanges();
            return true;
        }
        #endregion
    }
}
