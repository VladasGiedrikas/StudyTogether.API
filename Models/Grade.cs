using System;
namespace StudyTogether.API.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string StudentName { get; set; }
        public int GradeNumber { get; set; }
        public double GradePercent { get; set; }
        public DateTime DateDone { get; set; }
        public int QuizNumber { get; set; }
        public int StudentNumber { get; set; }
    }
}
