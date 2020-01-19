using System.Collections.Generic;

namespace StudyTogether.API.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string Group { get; set; }
        public int TotaltQuizzes { get; set; }
        public string Password { get; set; }
    }
}