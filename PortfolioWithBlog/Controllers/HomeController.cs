using EntityLayer.WebApplication.ViewModels.MessageViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.WebApplication.Services.Abstract;

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


        //Captcha
        public IActionResult Index()
        {
            var captcha = _messageService.CaptchaGenerator();
            return View(new MessageAddVM { CatpchaGenerated = captcha });

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

      
    }
}