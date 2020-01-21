namespace StudyTogether.API.Models
{
    //klasė modelis, pagal kuri kuriamas lenteles duonbazėje
    public class Question
    {
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionMain { get; set; }
        public string CorectAnswer { get; set; }
        public string IncorectFirst { get; set; }
        public string IncorectSecond { get; set; }
        public string IncorectThird { get; set; }
        public string Hint { get; set; }
        public int QuizNumber { get; set; }
    }
}
