using Microsoft.AspNetCore.Mvc;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class EducationUserViewComponent : ViewComponent
    {
        private readonly IEducationService _educationService;

        public EducationUserViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educationList = await _educationService.GetEducationForUserListAsync();
            return View(educationList);
        }
    }
}
