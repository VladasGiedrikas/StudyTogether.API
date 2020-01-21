using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudyTogether.API.Services
{
    public interface IQuizesServices
    {
        List<Quiz> GetAllQuizes();
        List<Quiz> GetQuizById(int quizId);
        bool InsertQuiz(List<Quiz> entries);
        bool InsertQuiz( Quiz entry);
        bool UpdateQuizesList(List<Quiz> entries);
        bool DeleteQuiz(int QuizId);
    }

    public class QuizesServices : IQuizesServices
    {
        private readonly StudyTogetherDbContext _context;
        public QuizesServices(StudyTogetherDbContext context)
        {
            _context = context;
        }

        public List<Quiz> GetAllQuizes()
        {
            return _context.Quizzes.ToList();                      
        }

        public List<Quiz> GetQuizById(int quizId)
        {          
            var entry = _context.Quizzes.Where(x => x.StudentNumber == quizId).ToList();               
            return entry;
        }

        public bool InsertQuiz(List<Quiz> entries)
        {
            _context.Quizzes.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateQuizesList(List<Quiz> entries)
        {
            var quizNumber = entries.Select(x => x.QuizNumber).FirstOrDefault(); 
            var delete = _context.Quizzes.Where(x => x.QuizNumber == quizNumber);
            _context.Quizzes.RemoveRange(delete);
            _context.Quizzes.AddRange(entries);
            _context.SaveChanges();
            return true;
        }


        public bool InsertQuiz(Quiz entry)
        {                    
            _context.Quizzes.Add(entry);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteQuiz(int QuizId)
        {

            var delete = _context.Quizzes.FirstOrDefault(x => x.QuizNumber.Equals(QuizId));
            _context.Quizzes.Remove(delete);
            _context.SaveChanges();
            return true;
        }
    }
}
