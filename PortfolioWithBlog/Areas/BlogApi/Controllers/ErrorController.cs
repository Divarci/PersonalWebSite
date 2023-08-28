using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Area("BlogApi")]
    public class ErrorController : Controller
    {
        public IActionResult NotFound(List<string> errors)
        {
            
            return View(errors);
        }
    }
}
