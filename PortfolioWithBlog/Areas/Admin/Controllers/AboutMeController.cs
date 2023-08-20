using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;
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
    public class AboutMeController : Controller
    {
        private readonly IAboutMeService _aboutMeService;
        private readonly IValidator<AboutMeAddVM> _validatorAdd;
        private readonly IValidator<AboutMeUpdateVM> _validatorUpdate;

        public AboutMeController(IAboutMeService aboutMeService, IValidator<AboutMeAddVM> validatorAdd, IValidator<AboutMeUpdateVM> validatorUpdate)
        {
            _aboutMeService = aboutMeService;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
        }

        //List
        public async Task<IActionResult> AboutMeListWithAllChildren()
        {
            var aboutMe = await _aboutMeService.GetAboutMeWithAllChildrenAsync();
            return View(aboutMe);
        }

        //Add
        [ServiceFilter(typeof(AboutMeDataCheckFilter))]
        [HttpGet]
        public IActionResult AboutMeAddWithAllChildren()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AboutMeAddWithAllChildren(AboutMeAddVM request)
        {
            var resultAboutMe = await _validatorAdd.ValidateAsync(request);
            if (resultAboutMe.IsValid)
            {
                await _aboutMeService.AddAboutMeAsync(request);
                return RedirectToAction("AboutMeListWithAllChildren", "AboutMe", new { Area = ("Admin") });
            }
            else
            {
                resultAboutMe.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<AboutMe>))]
        [HttpGet]
        public async Task<IActionResult> AboutMeUpdateWithAllChildren(int id)
        {
            var aboutMe = await _aboutMeService.GetAboutMeWithAllChildrenByIdAsync(id);
            return View(aboutMe);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AboutMeUpdateWithAllChildren(AboutMeUpdateVM request)
        {
            var resultAboutMe = await _validatorUpdate.ValidateAsync(request);
            if (resultAboutMe.IsValid)
            {
                await _aboutMeService.UpdateAboutMeAsync(request);
                return RedirectToAction("AboutMeListWithAllChildren", "AboutMe", new { Area = ("Admin") });
            }
            else
            {
                resultAboutMe.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<AboutMe>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteAboutMeWithAllChildren(int id)
        {
            await _aboutMeService.DeleteAboutMeAsync(id);
            return RedirectToAction("AboutMeListWithAllChildren", "AboutMe", new { Area = ("Admin") });
        }


    }
}
