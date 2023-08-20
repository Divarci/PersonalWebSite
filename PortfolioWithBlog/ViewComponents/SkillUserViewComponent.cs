using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class SkillUserViewComponent : ViewComponent
    {
        private readonly ISkillService _skillService;

        public SkillUserViewComponent(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skills = await _skillService.GetSkillListForUserAsync();
            return View(skills);
        }
    }
}
