namespace SurveysApp.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public Question? Question { get; set; }

        public Response? Response { get; set; }

        public int ChoiceId { get; set; }
    }
}
