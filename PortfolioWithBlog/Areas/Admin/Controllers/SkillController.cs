using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SkillViewModel;
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

    public class SkillController: Controller
    {
        private readonly ISkillService _skillService;
        private readonly IValidator<SkillAddVM> _validatorAdd;
        private readonly IValidator<SkillUpdateVM> _validatorUpdate;

        public SkillController(ISkillService skillService, IValidator<SkillAddVM> validatorAdd, IValidator<SkillUpdateVM> validatorUpdate)
        {
            _skillService = skillService;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
        }


        //List
        public async Task<IActionResult> SkillList()
        {
            var skill = await _skillService.GetSkillListAsync();
            return View(skill);
        }

        //Add
        [HttpGet]
        public IActionResult SkillAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> SkillAdd(SkillAddVM request)
        {
            var result = await _validatorAdd.ValidateAsync(request);
            if (result.IsValid)
            {
                await _skillService.AddSkillAsync(request);
                return RedirectToAction("SkillList", "Skill", new { Area = ("Admin") });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
           
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<Skill>))]
        [HttpGet]
        public async Task<IActionResult> SkillUpdate(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            return View(skill);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> SkillUpdate(SkillUpdateVM request)
        {
            var result = await _validatorUpdate.ValidateAsync(request);
            if (result.IsValid)
            {
                await _skillService.UpdateSkillAsync(request);
            return RedirectToAction("SkillList", "Skill", new { Area = ("Admin") });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Skill>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> SkillDelete(int id)
        {
            await _skillService.DeleteSkillAsync(id);
            return RedirectToAction("SkillList", "Skill", new { Area = ("Admin") });
        }
    }
}
