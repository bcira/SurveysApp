using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SurveysApp.Models
{
    public class SendSurveyLinkViewModel
    {
        [Required]
        [Display(Name = "Survey")]
        public int SurveyId { get; set; }

        public List<SelectListItem>? Surveys { get; set; }

        [Required]
        [Display(Name = "Users")]
        public List<string>? SelectedUserIds { get; set; }

        public List<AppUser>? Users { get; set; }
    }
}
