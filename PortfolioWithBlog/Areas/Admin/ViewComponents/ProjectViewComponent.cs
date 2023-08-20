using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.Admin.ViewComponents
{
    public class ProjectViewComponent : ViewComponent
    {
        private readonly IProjectService _projectService;

        public ProjectViewComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var projects = await _projectService.GetProjectListForDashboardAsync();
            return View(projects);
        }
    }
}
