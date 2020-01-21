using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudyTogether.API.Services
{
    public interface IAnswersServices
    {
        List<Answer> GetAllAnswers();
        List<Answer> GetAnswerById(int quizId);
        bool InsertAnswer(List<Answer> entries);
        bool InsertGrade(Grade entries);
        bool UpdateAnswersList(List<Answer> entries);
        bool DeleteAnswer(int AnswerId);
        double GetGrade(List<Answer> answers, int quizId);
    }

    public class AnswersServices : IAnswersServices
    {
        private readonly StudyTogetherDbContext _context;
        public AnswersServices(StudyTogetherDbContext context)
        {
            _context = context;
        }

        public List<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();                      
        }

        public List<Answer> GetAnswerById(int quizId)
        {
           
            var entry = _context.Answers.Where(x => x.QuizNumber == quizId).ToList();               
            return entry;
        }

        public bool InsertAnswer(List<Answer> entries)
        {
            _context.Answers.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateAnswersList(List<Answer> entries)
        {
            var quizNumber = entries.Select(x => x.QuizNumber).FirstOrDefault(); 
            var delete = _context.Answers.Where(x => x.QuizNumber == quizNumber);
            _context.Answers.RemoveRange(delete);
            _context.Answers.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteAnswer(int AnswerId)
        {

            var delete = _context.Answers.FirstOrDefault(x => x.AnswerNumber.Equals(AnswerId));
            _context.Answers.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public double GetGrade(List<Answer> answers, int quizId)
        {
            double totalCorect = 0;
            double score = 0;

            var Answers = _context.Answers.Where(x => x.QuizNumber == quizId).ToList();
                               
            foreach (var item in answers)
            {
                var test = Answers.Where(x => x.AnswerNumber == item.AnswerNumber).FirstOrDefault().CorectAnswer;
                if (test == item.StudentAnswer)
                {
                    totalCorect++;
                }
            }
            double alltotal = Answers.Count;
            score = ((totalCorect / alltotal) * 100);
            
            return score;
        }
        public bool InsertGrade(Grade entries)
        {
            _context.Grades.Add(entries);
            _context.SaveChanges();
            return true;
        }
    }
}
