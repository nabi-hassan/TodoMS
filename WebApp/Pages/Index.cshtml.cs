using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataService _dataService;

        public IndexModel(ILogger<IndexModel> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public async Task<IActionResult> OnGet()
        {
            var apiResponse = await _dataService.TodoGroups.Get();
            return Page();
        }
    }
}
