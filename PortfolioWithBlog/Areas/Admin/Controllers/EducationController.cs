using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Exceptions.Filters;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IValidator<EducationUpdateVM> _validatorUpdate;
        private readonly IValidator<EducationAddVM> _validatorAdd;

        public EducationController(IEducationService educationService, IValidator<EducationUpdateVM> validatorUpdate, IValidator<EducationAddVM> validatorAdd)
        {
            _educationService = educationService;
            _validatorUpdate = validatorUpdate;
            _validatorAdd = validatorAdd;
        }


        //List
        public async Task<IActionResult> EducationList()
        {
            var educations = await _educationService.GetEducationListAsync();
            return View(educations);
        }

        //Add
        [HttpGet]
        public IActionResult EducationAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> EducationAdd(EducationAddVM request)
        {
            var resultEducation = await _validatorAdd.ValidateAsync(request);
            if (resultEducation.IsValid)
            {
                await _educationService.AddEducationAsync(request);
                return RedirectToAction("EducationList", "Education", new { Area = ("Admin") });
            }
            else
            {
                resultEducation.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<Education>))]
        [HttpGet]
        public async Task<IActionResult> EducationUpdate(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            return View(education);

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> EducationUpdate(EducationUpdateVM request)
        {
            var resultEducation = await _validatorUpdate.ValidateAsync(request);
            if (resultEducation.IsValid)
            {
                await _educationService.UpdateEducationAsync(request);
                return RedirectToAction("EducationList", "Education", new { Area = ("Admin") });
            }
            else
            {
                resultEducation.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Education>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> EducationDelete(int id)
        {

            await _educationService.DeleteEducationAsync(id);
            return RedirectToAction("EducationList", "Education", new { Area = ("Admin") });

        }

    }
}
