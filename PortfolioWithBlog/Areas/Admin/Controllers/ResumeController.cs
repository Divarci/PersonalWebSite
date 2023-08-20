using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
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
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly IValidator<ResumeAddVM> _validatorAdd;
        private readonly IValidator<ResumeUpdateVM> _validatorUpdate;

        public ResumeController(IResumeService resumeService, IValidator<ResumeUpdateVM> validatorUpdate, IValidator<ResumeAddVM> validatorAdd)
        {
            _resumeService = resumeService;
            _validatorUpdate = validatorUpdate;
            _validatorAdd = validatorAdd;
        }



        //List
        public async Task<IActionResult> ActiveResumeList()
        {
            var activeResumeList = await _resumeService.GetActiveResumeListAsync();
            return View(activeResumeList);
        }
        public async Task<IActionResult> InactiveResumeList()
        {
            var inactiveResumeList = await _resumeService.GetInactiveResumeListAsync();
            return View(inactiveResumeList);
        }

        //Active-Inactive
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> MakeResumeInactive(int resumeId)
        {
            await _resumeService.SoftDeleteAsync(resumeId);
            return RedirectToAction("ActiveResumeList", "Resume", new { Area = "Admin" });
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> MakeResumeActive(int resumeId)
        {
            await _resumeService.ResumeActivateAsync(resumeId);
            return RedirectToAction("InactiveResumeList", "Resume", new { Area = "Admin" });
        }

        //Add
        [HttpGet]
        public IActionResult ResumeAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ResumeAdd(ResumeAddVM request)
        {
            var resultResume = await _validatorAdd.ValidateAsync(request);
            if (resultResume.IsValid)
            {
                await _resumeService.AddResumeAsync(request);
                return RedirectToAction("ActiveResumeList", "Resume", new { Area = "Admin" });
            }
            else
            {
                resultResume.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update 
        [ServiceFilter(typeof(GenericNotFoundFilter<Resume>))]
        [HttpGet]
        public async Task<IActionResult> ResumeUpdate(int resumeId)
        {
            var resume = await _resumeService.GetResumeByIdAsync(resumeId);
            return View(resume);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ResumeUpdate(ResumeUpdateVM request)
        {
            var resultResume = await _validatorUpdate.ValidateAsync(request);
            if (resultResume.IsValid)
            {
                await _resumeService.UpdateResumeAsync(request);
                return RedirectToAction("ActiveResumeList", "Resume", new { Area = "Admin" });
            }
            else
            {
                resultResume.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete 
        [ServiceFilter(typeof(GenericNotFoundFilter<Resume>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ResumeDelete(int resumeId)
        {
            await _resumeService.DeleteResumeAsync(resumeId);
            return RedirectToAction("InactiveResumeList", "Resume", new { Area = "Admin" });
        }


        //Publish-Unpublish
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ResumePublish(int id)
        {
            await _resumeService.MakeResumePublishedAsync(id);
            return RedirectToAction("ActiveResumeList", "Resume", new { Area = "Admin" });
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ResumeEditable(int id)
        {
            await _resumeService.MakeResumeEditableAsync(id);
            return RedirectToAction("ActiveResumeList", "Resume", new { Area = "Admin" });
        }
    }
}
