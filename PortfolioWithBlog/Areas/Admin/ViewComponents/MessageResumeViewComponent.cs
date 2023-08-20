using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.Admin.ViewComponents
{
    public class MessageResumeViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageResumeViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = await _messageService.GetMessageListForDashboardAsync();
            return View(messages);
        }
    }
}
