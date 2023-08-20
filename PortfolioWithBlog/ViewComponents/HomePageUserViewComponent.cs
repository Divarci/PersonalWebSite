using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class HomePageUserViewComponent : ViewComponent
    {
        private readonly IHomePageService _homePageService;

        public HomePageUserViewComponent(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var homePage = await _homePageService.HomePagePublishAsync();
            return View(homePage);
        }
    }
}
