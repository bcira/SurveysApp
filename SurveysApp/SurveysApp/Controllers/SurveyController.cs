using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveysApp.Data;
using SurveysApp.Models;


namespace SurveysApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly SurveyDbContext _dbContext;

        public SurveyController(SurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Survey survey)
        {
            _dbContext.Surveys.Add(survey);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Results(int surveyId)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                .FirstOrDefault(s => s.Id == surveyId);

            if (survey == null)
            {
                return NotFound();
            }

            var viewModel = new SurveyResultsViewModel
            {
                SurveyId = survey.Id,
                SurveyTitle = survey.Title,
                QuestionResults = new List<QuestionResultsViewModel>()
            };

            foreach (var question in survey.Questions)
            {
                var questionResult = new QuestionResultsViewModel
                {
                    QuestionId = question.Id,
                    QuestionText = question.Text,
                    ChoiceResults = new List<ChoiceResultsViewModel>()
                };

                foreach (var choice in question.Choices)
                {
                    var choiceResult = new ChoiceResultsViewModel
                    {
                        ChoiceId = choice.Id,
                        ChoiceText = choice.Text,
                        ResponseCount = _dbContext.Responses.Count(r => r.QuestionId == question.Id && r.ChoiceId == choice.Id)
                    };

                    questionResult.ChoiceResults.Add(choiceResult);
                }

                viewModel.QuestionResults.Add(questionResult);
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Details(int id)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        [HttpGet]
        public IActionResult TakeSurvey(int id)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Choices)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                return NotFound();
            }

            var viewModel = new Survey
            {
                Id = survey.Id,
                Title = survey.Title,
                Questions = survey.Questions.Select(q => new Question
                {
                    Id = q.Id,
                    Text = q.Text,
                    Choices = q.Choices.Select(c => new Choice
                    {
                        Id = c.Id,
                        Text = c.Text
                    }).ToList()
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TakeSurvey(Survey viewModel)
        {
            if (ModelState.IsValid)
            {
                // Save survey responses to the database
                foreach (var answer in viewModel.Answers)
                {
                    var response = new Response
                    {
                        QuestionId = answer.Id,
                        ChoiceId = answer.ChoiceId
                    };

                    _dbContext.Responses.Add(response);
                }

                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            // Re-display the survey form with validation errors
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Choices)
                .FirstOrDefault(s => s.Id == viewModel.Id);

            if (survey == null)
            {
                return NotFound();
            }

            viewModel.Title = survey.Title;
            viewModel.Questions = survey.Questions.Select(q => new Question
            {
                Id = q.Id,
                Text = q.Text,
                Choices = q.Choices.Select(c => new Choice
                {
                    Id = c.Id,
                    Text = c.Text
                }).ToList()
            }).ToList();

            return View(viewModel);
        }
    }
}

