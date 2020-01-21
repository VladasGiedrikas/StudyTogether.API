using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudyTogether.API.Services
{
    
    public interface IQuestionsServices
    {
        // interface metodu deklaracijos
        List<Question> GetAllQuestions();
        List<Question> GetQuestionById(int quizId);
        bool InsertQuestion(List<Question> entries);
        bool InsertQuiz( Quiz entry);
        bool UpdateQuestionsList(List<Question> entries);
        bool DeleteQuestion(int questionId);
    }

    //nurodome koki interface naudosime
    public class QuestionsServices : IQuestionsServices
    {
        private readonly StudyTogetherDbContext _context;
        public QuestionsServices(StudyTogetherDbContext context)
        {
            //konstriuktorius, kuriame priskirimas objektas 
            _context = context; 
        }

        // iplementuoti metodai nurodyti interface
        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();                      
        }

        public List<Question> GetQuestionById(int quizId)
        {
           
            var entry = _context.Questions.Where(x => x.QuizNumber == quizId).ToList();               
            return entry;
        }

        public bool InsertQuestion(List<Question> entries)
        {

            _context.Questions.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateQuestionsList(List<Question> entries)
        {
            var quizNumber = entries.Select(x => x.QuizNumber).FirstOrDefault(); 
            var delete = _context.Questions.Where(x => x.QuizNumber == quizNumber);
            _context.Questions.RemoveRange(delete);
            _context.Questions.AddRange(entries);
            _context.SaveChanges();
            return true;
        }

        public bool InsertQuiz(Quiz entry)
        {                    
            _context.Quizzes.Add(entry);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteQuestion(int questionId)
        {
            var delete = _context.Questions.FirstOrDefault(x => x.QuestionNumber.Equals(questionId));
            _context.Questions.Remove(delete);
            _context.SaveChanges();
            return true;
        }
    }
}
