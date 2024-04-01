using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace WebApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ExceptionModel : PageModel
    {
        public IActionResult OnGet(int? statusCode=null)
        {
            switch (statusCode)
            {
                case 500:
                    return RedirectToPage("/Errors/InternalServerError");
                case 404:
                    return RedirectToPage("/Errors/NotFound");
                default:
                    return Page();
            }

        }
    }

}
