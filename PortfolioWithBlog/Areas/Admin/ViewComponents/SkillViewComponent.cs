using Microsoft.AspNetCore.Mvc;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.Areas.Admin.ViewComponents
{
    public class SkillViewComponent : ViewComponent
    {
        private readonly ISkillService _skillService;

        public SkillViewComponent(ISkillService skillService)
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
