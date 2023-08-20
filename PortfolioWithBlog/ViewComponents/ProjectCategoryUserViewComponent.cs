using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class ProjectCategoryUserViewComponent : ViewComponent
    {
        private readonly IProjectCategoryService _projectCategoryService;

        public ProjectCategoryUserViewComponent(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCategoryList = await _projectCategoryService.GetProjectCategoryWithAllChildrenAsync();
            return View(allCategoryList);
        }
    }
}
