using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveysApp.Data;
using SurveysApp.Models;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SurveysApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly SurveyDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AdminController(SurveyDbContext dbContext, UserManager<AppUser> userManager, IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult SendSurveyLink()
        {
            var viewModel = new SendSurveyLinkViewModel
            {
                Users = _userManager.Users.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult SendSurveyLink(SendSurveyLinkViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var surveyUrl = Url.Action("TakeSurvey", "Survey", new { id = viewModel.SurveyId }, Request.Scheme);

                foreach (var userEmail in viewModel.SelectedUserIds)
                {
                    var user = _userManager.FindByEmailAsync(userEmail).Result;
                    if (user != null)
                    {
                        var message = new MailMessage
                        {
                            Subject = "Survey Invitation",
                            Body = $"Dear {user.UserName},<br><br>You are invited to participate in a survey. Please click the link below to access the survey:<br><br><a href=\"{surveyUrl}\">Take Survey</a>"
                        };

                        _emailSender.SendEmailAsync(user.Email, message.Subject, message.Body);
                    }
                }

                return RedirectToAction("Index", "Survey");
            }

            viewModel.Users = _userManager.Users.ToList();
            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

