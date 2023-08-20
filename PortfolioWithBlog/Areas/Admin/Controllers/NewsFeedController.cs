using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.NewsFeedVM;
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
    public class NewsFeedController : Controller
    {
        private readonly INewsFeedService _newsFeedService;
        private readonly IValidator<NewsFeedAddVM> _newsFeedAddValidator;
        private readonly IValidator<NewsFeedUpdateVM> _newsFeedUpdateValidator;

        public NewsFeedController(INewsFeedService newsFeedService, IValidator<NewsFeedAddVM> newsFeedAddValidator, IValidator<NewsFeedUpdateVM> newsFeedUpdateValidator)
        {
            _newsFeedService = newsFeedService;
            _newsFeedAddValidator = newsFeedAddValidator;
            _newsFeedUpdateValidator = newsFeedUpdateValidator;
        }


        //List
        public async Task<IActionResult> GetNewsList()
        {
            var newsFeedList = await _newsFeedService.GetNewsListForAdminAsync();
            return View(newsFeedList);
        }

        //Add
        [HttpGet]
        public IActionResult NewsFeedAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> NewsFeedAdd(NewsFeedAddVM request)
        {
            var resultModelValidator = await _newsFeedAddValidator.ValidateAsync(request);
            if (!resultModelValidator.IsValid)
            {
                resultModelValidator.AddToModelState(this.ModelState);
                return View();
            }
            await _newsFeedService.AddNewsFeed(request);
            return RedirectToAction("GetNewsList", "NewsFeed", new { Area = ("Admin") });
        }

        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<NewsFeed>))]
        [HttpGet]
        public async Task<IActionResult> NewsFeedUpdate(int id)
        {
            var news = await _newsFeedService.GetNewsByIdAsync(id);
            return View(news);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> NewsFeedUpdate(NewsFeedUpdateVM request)
        {
            var resultModelValidator = await _newsFeedUpdateValidator.ValidateAsync(request);
            if (!resultModelValidator.IsValid)
            {
                resultModelValidator.AddToModelState(this.ModelState);
                return View();
            }
            await _newsFeedService.UpdateNewsFeed(request);
            return RedirectToAction("GetNewsList", "NewsFeed", new { Area = ("Admin") });
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<NewsFeed>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> NewsFeedDelete(int id)
        {
            await _newsFeedService.DeleteNewsFeedById(id);
            return RedirectToAction("GetNewsList", "NewsFeed", new { Area = ("Admin") });
        }
    }
}