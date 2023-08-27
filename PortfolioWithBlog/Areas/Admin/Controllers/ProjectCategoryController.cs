using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Exceptions.Filters.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]    
    [Area("Admin")]
    public class ProjectCategoryController : Controller
    {
        private readonly IProjectCategoryService _categoryService;
        private readonly IValidator<ProjectCategoryUpdateVM> _validatorUpdate;
        private readonly IValidator<ProjectCategoryAddVM> _validatorAdd;

        public ProjectCategoryController(IProjectCategoryService categoryService, IValidator<ProjectCategoryUpdateVM> validatorUpdate, IValidator<ProjectCategoryAddVM> validatorAdd)
        {
            _categoryService = categoryService;
            _validatorUpdate = validatorUpdate;
            _validatorAdd = validatorAdd;
        }


        //List
        public async Task<IActionResult> ProjectCategoryList()
        {
            var categories = await _categoryService.GetProjectCategoryListAsync();
            return View(categories);
        }

        //Add
        [HttpGet]
        public IActionResult ProjectCategoryAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectCategoryAdd(ProjectCategoryAddVM request)
        {
            var resultProjectCategory = await _validatorAdd.ValidateAsync(request);
            if (resultProjectCategory.IsValid)
            {
                await _categoryService.AddProjectCategoryAsync(request);
                return RedirectToAction("ProjectCategoryList", "ProjectCategory", new { Area = ("Admin") });
            }
            else
            {
                resultProjectCategory.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<ProjectCategory>))]
        [HttpGet]
        public async Task<IActionResult> ProjectCategoryUpdate(int id)
        {
            var category = await _categoryService.GetProjectCategoryByIdAsync(id);
            return View(category);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectCategoryUpdate(ProjectCategoryUpdateVM request)
        {
            var resultProjectCategory = await _validatorUpdate.ValidateAsync(request);
            if (resultProjectCategory.IsValid)
            {
                await _categoryService.UpdateProjectCategoryAsync(request);
                return RedirectToAction("ProjectCategoryList", "ProjectCategory", new { Area = ("Admin") });
            }
            else
            {
                resultProjectCategory.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<ProjectCategory>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ProjectCategoryDelete(int id)
        {
            await _categoryService.DeleteProjectCategoryAsync(id);
            return RedirectToAction("ProjectCategoryList", "ProjectCategory", new { Area = ("Admin") });

        }


    }
}
