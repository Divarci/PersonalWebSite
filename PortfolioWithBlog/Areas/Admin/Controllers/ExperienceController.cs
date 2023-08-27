using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;
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

    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IValidator<ExperienceUpdateVM> _validatorUpdate;
        private readonly IValidator<ExperienceAddVM> _validatorAdd;

        public ExperienceController(IExperienceService experienceService, IValidator<ExperienceUpdateVM> validatorUpdate, IValidator<ExperienceAddVM> validatorAdd)
        {
            _experienceService = experienceService;
            _validatorUpdate = validatorUpdate;
            _validatorAdd = validatorAdd;
        }


        //List
        public async Task<IActionResult> ExperienceList()
        {
            var experience = await _experienceService.GetExperienceListAsync();
            return View(experience);
        }

        //Add
        [HttpGet]
        public IActionResult ExperienceAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ExperienceAdd(ExperienceAddVM request)
        {
            var resultExperience = await _validatorAdd.ValidateAsync(request);
            if (resultExperience.IsValid)
            {
                await _experienceService.AddExperienceAsync(request);
                return RedirectToAction("ExperienceList", "Experience", new { Area = ("Admin") });
            }
            else
            {
                resultExperience.AddToModelState(this.ModelState);
                return View();
            }

        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<Experience>))]
        [HttpGet]
        public async Task<IActionResult> ExperienceUpdate(int id)
        {
            var experience = await _experienceService.GetExperienceByIdAsync(id);
            return View(experience);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ExperienceUpdate(ExperienceUpdateVM request)
        {
            var resultExperience = await _validatorUpdate.ValidateAsync(request);
            if (resultExperience.IsValid)
            {
                await _experienceService.UpdateExperienceAsync(request);
                return RedirectToAction("ExperienceList", "Experience", new { Area = ("Admin") });
            }
            else
            {
                resultExperience.AddToModelState(this.ModelState);
                return View();
            }


        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Experience>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ExperienceDelete(int id)
        {
            await _experienceService.DeleteExperienceAsync(id);
            return RedirectToAction("ExperienceList", "Experience", new { Area = ("Admin") });
        }


    }
}
