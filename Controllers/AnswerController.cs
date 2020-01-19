using Microsoft.AspNetCore.Mvc;
using StudyTogether.API.Models;
using StudyTogether.API.Services;
using System.Collections.Generic;

namespace StudyTogether.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersServices _main;

        public AnswersController(IAnswersServices main)
        {
            _main = main;
        }

        [HttpGet("", Name = "Answers_GetAllAnswers")]
        public ActionResult<List<Answer>> GetAllAnswers()
        {
            return _main.GetAllAnswers();
        }

        [HttpGet("quizId", Name = "Answers_GetAnswerById")]
        public ActionResult<List<Answer>> GetAnswerById(int quizId)
        {
            return _main.GetAnswerById(quizId);
        }

        [HttpPost("", Name = "Answers_InsertAnswer")]
        public ActionResult<bool> InsertAnswer([FromBody] List<Answer> entries)
        {
            return _main.InsertAnswer(entries);
        }

        [HttpPost("insetGrade", Name = "Answers_InsertGrade")]
        public ActionResult<bool> InsertGrade([FromBody] Grade entries)
        {
            return _main.InsertGrade(entries);
        }


        [HttpPost("list", Name = "Answers_UpdateAnswersList")]
        public ActionResult<bool> UpdateAnswersList([FromBody] List<Answer> entries)
        {
            return _main.UpdateAnswersList(entries);
        }

        [HttpDelete("AnswerId", Name = "Answers_DeleteAnswer")]
        public ActionResult<bool> DeleteAnswer(int AnswerId)
        {
            return _main.DeleteAnswer(AnswerId);
        }

        [HttpPost("grade", Name = "Answers_GetGrade")]
        public ActionResult<double> GetGrade([FromBody] List<Answer> entries, int quizId)
        {
            return _main.GetGrade(entries, quizId);
        }
    }
}
