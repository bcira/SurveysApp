namespace SurveysApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public required ICollection<Choice> Choices { get; set; }

    }
}
