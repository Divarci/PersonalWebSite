using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.WebApplication.Filters;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]    
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IValidator<ProjectAddVM> _validatorAdd;
        private readonly IValidator<ProjectUpdateVM> _validatorUpdate;

        public ProjectController(IProjectService projectService, IValidator<ProjectAddVM> validatorAdd, IValidator<ProjectUpdateVM> validatorUpdate)
        {
            _projectService = projectService;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
        }


        //List
        public async Task<IActionResult> ProjectList()
        {
            var projects = await _projectService.GetProjectListAsync();
            return View(projects);
        }

        //Add
        [HttpGet]
        public async Task<IActionResult> ProjectAdd()
        {
            var categories = await _projectService.GetCategoriesForProjectAsync();
            return View(new ProjectAddVM { Categories = categories });
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectAdd(ProjectAddVM request)
        {
            var categories = await _projectService.GetCategoriesForProjectAsync();
            var resultProject = await _validatorAdd.ValidateAsync(request);
            if (resultProject.IsValid)
            {
                await _projectService.AddProjectAsync(request);
                return RedirectToAction("ProjectList", "Project", new { Area = ("Admin") });
            }
            else
            {
                resultProject.AddToModelState(this.ModelState);
                return View(new ProjectAddVM { Categories = categories });
            }

        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<Project>))]
        [HttpGet]
        public async Task<IActionResult> ProjectUpdate(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            project.Categories = await _projectService.GetCategoriesForProjectAsync();

            return View(project);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectUpdate(ProjectUpdateVM request)
        {
            var project = await _projectService.GetProjectByIdAsync(request.Id);
            project.Categories = await _projectService.GetCategoriesForProjectAsync();

            var resultProject = await _validatorUpdate.ValidateAsync(request);
            if (resultProject.IsValid)
            {
                await _projectService.UpdateProjectAsync(request);
                return RedirectToAction("ProjectList", "Project", new { Area = ("Admin") });
            }
            else
            {
                resultProject.AddToModelState(this.ModelState);
                return View(project);
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Project>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ProjectDelete(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction("ProjectList", "Project", new { Area = ("Admin") });
        }

        //Select Project
        public async Task<IActionResult> ProjectDetail(int id)
        {
            var project = await _projectService.GetProjectByIdFordetailAsync(id);
            return View(project);
        }

    }
}
