using ActivityTest.Query.ActivityTypeQuery.DTOs;
using ActivityTest.RazorPage.Services.ActivityType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActivityTest.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IActivityTypeService _service;
        public IndexModel(IActivityTypeService service)
        {
            _service = service;
        }

        [BindProperty]
        public List<ActivityTypeDTO?> ActivityTypes { get; set; }

        public async Task OnGet()
        {
            ActivityTypes = await _service.GetList();
        }
    }
}