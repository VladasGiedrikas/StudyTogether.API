using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudyTogether.API.Services
{
    public interface IGradeServices
    {
        List<Grade> GetAllGrades();
        List<Grade> GetGradeById(int quizId);
        bool InsertGrade(Grade entries);
        bool UpdateGradesList(List<Grade> entries);
        bool DeleteGrade(int GradeId);
        double GetGrade(List<Answer> answers, int quizId);
    }

    public class GradeServices : IGradeServices
    {
        private readonly StudyTogetherDbContext _context;
        public GradeServices(StudyTogetherDbContext context)
        {
            _context = context;
        }

        public List<Grade> GetAllGrades()
        {
            return _context.Grades.ToList();                      
        }

        public List<Grade> GetGradeById(int quizId)
        {
           
            var entry = _context.Grades.Where(x => x.QuizNumber == quizId).ToList();               
            return entry;
        }

        public bool InsertGrade(Grade entries)
        {
            _context.Grades.Add(entries);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateGradesList(List<Grade> entries)
        {
            var quizNumber = entries.Select(x => x.QuizNumber).FirstOrDefault(); 
            var delete = _context.Grades.Where(x => x.QuizNumber == quizNumber);
            _context.Grades.RemoveRange(delete);
            _context.Grades.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteGrade(int GradeId)
        {

            var delete = _context.Grades.FirstOrDefault(x => x.GradeNumber.Equals(GradeId));
            _context.Grades.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public double GetGrade(List<Answer> answers, int quizId)
        {
            double totalCorect = 0;
            double score = 0;

            var questions = _context.Questions.Where(x => x.QuizNumber == quizId).ToList();

            foreach (var item in answers)
            {
                var test = questions.Where(x => x.QuestionNumber == item.QuestionNumber).FirstOrDefault().CorectAnswer;
                if (test == item.StudentAnswer)
                {
                    totalCorect++;
                }
            }
            double alltotal = questions.Count;
            score = Math.Round(((totalCorect / alltotal) * 10), 2);
            return score;
        }
    }
}
