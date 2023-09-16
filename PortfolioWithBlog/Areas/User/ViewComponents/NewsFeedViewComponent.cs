using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.Areas.User.ViewComponents
{
    public class NewsFeedViewComponent : ViewComponent
    {
        private readonly INewsFeedService _newsFeedService;

        public NewsFeedViewComponent(INewsFeedService newsFeedService)
        {
            _newsFeedService = newsFeedService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var newsFeedList = await _newsFeedService.GetLastFiveNewsListForUserAsync();
            return View(newsFeedList);
        }
    }
}
