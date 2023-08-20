using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageViewModel;
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
    public class HomePageController : Controller
    {
        private readonly IHomePageService _homePageService;
        private readonly IValidator<HomePageAddVM> _validatorAdd;
        private readonly IValidator<HomePageUpdateVM> _validatorUpdate;

        public HomePageController(IHomePageService homePageService, IValidator<HomePageAddVM> validatorAdd, IValidator<HomePageUpdateVM> validatorUpdate)
        {
            _homePageService = homePageService;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
        }


        //List
        public async Task<IActionResult> HomePageList()
        {
            var homePageList = await _homePageService.GetHomePageListAsync();
            return View(homePageList);
        }

        //Add
        [ServiceFilter(typeof(HomePageDataCheckFilter))]
        [HttpGet]
        public IActionResult HomePageAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> HomePageAdd(HomePageAddVM request)
        {
            var resultHomaPage = await _validatorAdd.ValidateAsync(request);
            if (resultHomaPage.IsValid)
            {
                await _homePageService.AddHomePageAsync(request);
                return RedirectToAction("HomePageList", "HomePage", new { Area = ("Admin") });
            }
            else
            {
                resultHomaPage.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<HomePage>))]
        [HttpGet]
        public async Task<IActionResult> HomePageUpdate(int id)
        {
            var homePage = await _homePageService.GetHomePageByIdAsync(id);
            return View(homePage);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> HomePageUpdate(HomePageUpdateVM request)
        {
            var resultHomaPage = await _validatorUpdate.ValidateAsync(request);
            if (resultHomaPage.IsValid)
            {
                await _homePageService.UpdateHomePageAsync(request);
                return RedirectToAction("HomePageList", "HomePage", new { Area = ("Admin") });
            }
            else
            {
                resultHomaPage.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<HomePage>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> HomePageDelete(int id)
        {
            await _homePageService.DeleteHomePageAsync(id);
            return RedirectToAction("HomePageList", "HomePage", new { Area = ("Admin") });

        }

    }
}
