using StudyTogether.API.Data;
using StudyTogether.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudyTogether.API.Services
{

    public interface IQuestionsServices
    {
        List<Question> GetAllQuestions();
        List<Question> GetQuestionById(int quizId);
        bool InsertQuestion(List<Question> entries);
        bool InsertQuiz( Quiz entry);
        bool UpdateQuestionsList(List<Question> entries);
        bool DeleteQuestion(int questionId);
        double GetGrade(List<Answer> answers, int quizId);
    }

    public class QuestionsServices : IQuestionsServices
    {
        private readonly StudyTogetherDbContext _context;
        public QuestionsServices(StudyTogetherDbContext context)
        {
            _context = context;
        }
        #region GET

        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();                      
        }

        public List<Question> GetQuestionById(int quizId)
        {
           
            var entry = _context.Questions.Where(x => x.QuizNumber == quizId).ToList();               
            return entry;
        }

        #endregion

        #region POST

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

        #endregion

        #region PUT

        public bool InsertQuiz(Quiz entry)
        {                    
            _context.Quizzes.Add(entry);
            _context.SaveChanges();
            return true;
        }

        #endregion

        #region DELETE

        public bool DeleteQuestion(int questionId)
        {

            var delete = _context.Questions.FirstOrDefault(x => x.QuestionNumber.Equals(questionId));
            _context.Questions.Remove(delete);
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
            score = ((totalCorect / alltotal) * 10);            
            return score;
        }
        #endregion
    }
}
