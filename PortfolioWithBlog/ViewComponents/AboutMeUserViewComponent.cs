using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class AboutMeUserViewComponent : ViewComponent
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutMeUserViewComponent(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutMe = await _aboutMeService.GetAboutMeWithAllChildrenForUserAsync();
            return View(aboutMe);
        }
    }
}
