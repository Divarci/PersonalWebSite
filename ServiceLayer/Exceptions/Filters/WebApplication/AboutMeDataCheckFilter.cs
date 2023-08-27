using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.Generic.Abstract;

namespace ServiceLayer.Exceptions.Filters.WebApplication
{
    public class AboutMeDataCheckFilter : IAsyncActionFilter
    {
        private readonly IGenericRepository<AboutMe> _genericRepository;

        public AboutMeDataCheckFilter(IGenericRepository<AboutMe> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //my concept allows me to have just one aboutme section in a resume. So if i have one, this filter prevents to add a new one
            var aboutMe = await _genericRepository.Where(x => x.IsEdited == true).SingleOrDefaultAsync();

            if (aboutMe != null)
            {
                context.Result = new RedirectToActionResult("AboutMeListWithAllChildren", "AboutMe", new { Area = "Admin" });
                return;
            }

            await next.Invoke();
            return;

        }
    }
}

