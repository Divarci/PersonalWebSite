using Microsoft.AspNetCore.Mvc;

namespace PortfolioWithBlog.Areas.GuildWarsTwo.Controllers
{
    [Area("GuildWarsTwo")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
