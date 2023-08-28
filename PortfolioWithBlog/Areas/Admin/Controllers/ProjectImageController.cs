using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
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
    public class ProjectImageController : Controller
    {
        private readonly IProjectImageService _imageService;
        private readonly IValidator<ProjectImageAddVM> _valodatorAdd;

        public ProjectImageController(IProjectImageService imageService, IValidator<ProjectImageAddVM> valodatorAdd)
        {
            _imageService = imageService;
            _valodatorAdd = valodatorAdd;
        }


        //List
        public async Task<IActionResult> ProjectImageList(int id)
        {
            var images = await _imageService.GetAllImageAsync(id);
            ViewBag.ProjectId = id;
            return View(images);
        }

        //Add
        [HttpGet]
        public async Task<IActionResult> ProjectImageAdd(int id)
        {
            var project = await _imageService.GetProjectByIdAsync(id);
            return View(new ProjectImageAddVM { ProjectId = project.Id, Title = project.Title });
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectImageAdd(ProjectImageAddVM request)
        {
            var project = await _imageService.GetProjectByIdAsync(request.ProjectId);
            var resultImage = await _valodatorAdd.ValidateAsync(request);
            if (resultImage.IsValid)
            {
                await _imageService.AddImageAsync(request);
                return RedirectToAction("ProjectImageList", "ProjectImage", new { Area = ("Admin"), id = request.ProjectId });
            }
            else
            {
                resultImage.AddToModelState(this.ModelState);
                return View(new ProjectImageAddVM { ProjectId = project.Id, Title = project.Title });
            }

        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<ProjectImage>))]
        [HttpGet]
        public async Task<IActionResult> ProjectImageUpdate(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            return View(image);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ProjectImageUpdate(ProjectImageUpdateVM request)
        {

            await _imageService.UpdateImageAsync(request);
            return RedirectToAction("ProjectImageList", "ProjectImage", new { Area = ("Admin"), id = request.ProjectId });

        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<ProjectImage>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ProjectImageDelete(int id)
        {
            var projectId = await _imageService.DeleteImage(id);
            return RedirectToAction("ProjectImageList", "ProjectImage", new { Area = ("Admin"), id = projectId });
        }
    }
}
