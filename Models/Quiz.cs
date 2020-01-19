namespace StudyTogether.API.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int QuizNumber { get; set; }
        public string QuizName { get; set; }
        public string Course { get; set; }
        public string Owner { get; set; }
        public int StudentNumber { get; set; }
    }
}
