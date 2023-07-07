namespace SurveysApp.Models
{

    public class SurveyResultsViewModel
    {
        public int SurveyId { get; set; }
        public string? SurveyTitle { get; set; }
        public required List<QuestionResultsViewModel> QuestionResults { get; set; }
    }

    public class QuestionResultsViewModel
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public required List<ChoiceResultsViewModel> ChoiceResults { get; set; }
    }

    public class ChoiceResultsViewModel
    {
        public int ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
        public int ResponseCount { get; set; }
    }
}

