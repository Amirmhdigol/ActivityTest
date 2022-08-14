using ActivityTest.Application.ActivityType.Add;
using ActivityTest.RazorPage.Services.ActivityType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ActivityTest.RazorPage.Pages
{
    [BindProperties]
    public class AddModel : PageModel
    {
        private readonly IActivityTypeService _activityTypeService;
        public AddModel(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string Name { get; set; }
        
        [Display(Name = "LogInformation")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string LogInformation { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please enter {0}")]
        public int Code { get; set; }
        
        [Display(Name = "IsActive")]
        [Required(ErrorMessage = "Please enter {0}")]
        public bool IsActive { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var model = new AddActivityTypeCommand
            {
                IsActive = IsActive,
                Name = Name,
                Code = Code,
                LogInformation = LogInformation
            };

            var result = await _activityTypeService.Add(model);

            if (result.IsSuccess == true)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}