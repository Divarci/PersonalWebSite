using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.WebApplication.Filters;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]    
    [Area("Admin")]

    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        //List
        public async Task<IActionResult> MessageList()
        {
            var messageList = await _messageService.GetMessageListAsync();
            return View(messageList);
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Message>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> MessageDelete(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return RedirectToAction("MessageList", "Message", new { Area = ("Admin") });

        }

    }
}
