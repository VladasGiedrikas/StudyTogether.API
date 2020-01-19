using Microsoft.AspNetCore.Mvc;
using StudyTogether.API.Models;
using StudyTogether.API.Services;
using System.Collections.Generic;

namespace StudyTogether.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizesServices _main;

        public QuizController(IQuizesServices main)
        {
            _main = main;
        }

        [HttpGet("", Name = "Quizes_GetAllQuizes")]
        public ActionResult<List<Quiz>> GetAllQuizes()
        {
            return _main.GetAllQuizes();
        }

        [HttpGet("quizId", Name = "Quizes_GetQuizById")]
        public ActionResult<List<Quiz>> GetQuizById(int quizId)
        {
            return _main.GetQuizById(quizId);
        }

        [HttpPost("", Name = "Quizes_InsertQuiz")]
        public ActionResult<bool> InsertQuiz([FromBody] List<Quiz> entries)
        {
            return _main.InsertQuiz(entries);
        }


        [HttpPost("insertQuiz", Name = "Quizes_InserQuiz")]
        public ActionResult<bool> InsertQuiz([FromBody] Quiz entry)
        {
            return _main.InsertQuiz(entry);
        }


        [HttpPost("list", Name = "Quizes_UpdateQuizesList")]
        public ActionResult<bool> UpdateQuizesList([FromBody] List<Quiz> entries)
        {
            return _main.UpdateQuizesList(entries);
        }

        [HttpDelete("QuizId", Name = "Quizes_DeleteQuiz")]
        public ActionResult<bool> DeleteQuiz(int QuizId)
        {
            return _main.DeleteQuiz(QuizId);
        }
    }
}
