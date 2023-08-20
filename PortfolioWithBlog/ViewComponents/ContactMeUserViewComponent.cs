using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class ContactMeUserViewComponent : ViewComponent
    {
        private readonly IAboutMeService _aboutMeServiceforContact;

        public ContactMeUserViewComponent(IAboutMeService aboutMeServiceforContact)
        {
            _aboutMeServiceforContact = aboutMeServiceforContact;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactList = await _aboutMeServiceforContact.GetContactListForUserAsync();
            return View(contactList);
        }
    }
}
