using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class ExperienceUserViewComponent : ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public ExperienceUserViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experienceList = await _experienceService.GetExperienceForUserListAsync();
            return View(experienceList);
        }
    }
}
