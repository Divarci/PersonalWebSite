using CoreLayer.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]
    [Area("Admin")]
    public class DashboardController : Controller
    {

        //Dashboard Page
        public IActionResult Index()
        {
            return View();
        }

        //Exception Pages
        public IActionResult ValueNotFound(ErrorVM error)
        {
            return View(error);
        }
    }
}
