namespace SurveysApp.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string? Answer { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }

    }
}
