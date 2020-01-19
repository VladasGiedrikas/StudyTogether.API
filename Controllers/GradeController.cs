using Microsoft.AspNetCore.Mvc;
using StudyTogether.API.Models;
using StudyTogether.API.Services;
using System.Collections.Generic;

namespace StudyTogether.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeServices _main;

        public GradeController(IGradeServices main)
        {
            _main = main;
        }

        [HttpGet("", Name = "Grades_GetAllGrades")]
        public ActionResult<List<Grade>> GetAllGrades()
        {
            return _main.GetAllGrades();
        }

        [HttpGet("quizId", Name = "Grades_GetGradeById")]
        public ActionResult<List<Grade>> GetGradeById(int quizId)
        {
            return _main.GetGradeById(quizId);
        }

        [HttpPost("", Name = "Grades_InsertGrade")]
        public ActionResult<bool> InsertGrade([FromBody] List<Grade> entries)
        {
            return _main.InsertGrade(entries);
        }

        [HttpPost("insetGrade", Name = "Grades_InsertGrade")]
        public ActionResult<bool> InsertGrade([FromBody] Grade entries)
        {
            return _main.InsertGrade(entries);
        }


        [HttpPost("list", Name = "Grades_UpdateGradesList")]
        public ActionResult<bool> UpdateGradesList([FromBody] List<Grade> entries)
        {
            return _main.UpdateGradesList(entries);
        }

        [HttpDelete("GradeId", Name = "Grades_DeleteGrade")]
        public ActionResult<bool> DeleteGrade(int GradeId)
        {
            return _main.DeleteGrade(GradeId);
        }

        [HttpPost("grade", Name = "Grades_GetGrade")]
        public ActionResult<double> GetGrade([FromBody] List<Answer> entries, int quizId)
        {
            return _main.GetGrade(entries, quizId);
        }
    }
}
