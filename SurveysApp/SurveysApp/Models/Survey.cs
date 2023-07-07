namespace SurveysApp.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public required ICollection<Question> Questions { get; set; }

        public ICollection<Response>? Responses { get; set; }
        public IEnumerable<Answer>? Answers { get; internal set; }

    }
}
