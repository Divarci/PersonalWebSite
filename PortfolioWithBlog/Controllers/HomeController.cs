using EntityLayer.WebApplication.ViewModels.MessageViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IValidator<MessageAddVM> _validatorAdd;

        public HomeController(IMessageService messageService, IValidator<MessageAddVM> validatorAdd)
        {
            _messageService = messageService;
            _validatorAdd = validatorAdd;
        }


        //----------
        public IActionResult Index()
        {
            return View();
        }
        
        //Send Message Partial View
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageAddVM request)
        {
            var resultAboutMe = await _validatorAdd.ValidateAsync(request);
            if (resultAboutMe.IsValid)
            {
                await _messageService.AddMessageAsync(request);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                resultAboutMe.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Exception Pages
        public IActionResult PageNotFound()
        {
            return View();
        }
        public IActionResult GeneralException()
        {
            return View();
        }
    }
}