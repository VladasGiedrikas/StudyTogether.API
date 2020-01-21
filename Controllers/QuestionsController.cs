using Microsoft.AspNetCore.Mvc;
using StudyTogether.API.Models;
using StudyTogether.API.Services;
using System.Collections.Generic;

namespace StudyTogether.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsServices _main;

        public QuestionsController(IQuestionsServices main)
        {
            _main = main;
        }

        [HttpGet("", Name = "Questions_GetAllQuestions")]
        public ActionResult<List<Question>> GetAllQuestions()
        {
            return _main.GetAllQuestions();
        }

        [HttpGet("quizId", Name = "Questions_GetQuestionById")]
        public ActionResult<List<Question>> GetQuestionById(int quizId)
        {
            return _main.GetQuestionById(quizId);
        }

        [HttpPost("", Name = "Questions_InsertQuestion")]
        public ActionResult<bool> InsertQuestion([FromBody] List<Question> entries)
        {
            return _main.InsertQuestion(entries);
        }


        [HttpPost("insertQuiz", Name = "Questions_InserQuiz")]
        public ActionResult<bool> InsertQuiz([FromBody] Quiz entry)
        {
            return _main.InsertQuiz(entry);
        }


        [HttpPost("list", Name = "Questions_UpdateQuestionsList")]
        public ActionResult<bool> UpdateQuestionsList([FromBody] List<Question> entries)
        {
            return _main.UpdateQuestionsList(entries);
        }

        [HttpDelete("questionId", Name = "Questions_DeleteQuestion")]
        public ActionResult<bool> DeleteQuestion(int questionId)
        {
            return _main.DeleteQuestion(questionId);
        }
    }
}
