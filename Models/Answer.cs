namespace StudyTogether.API.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int AnswerNumber { get; set; }
        public int QuestionNumber { get; set; }
        public string CorectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public int QuizNumber { get; set; }
        public int StudentNumber { get; set; }
    }
}