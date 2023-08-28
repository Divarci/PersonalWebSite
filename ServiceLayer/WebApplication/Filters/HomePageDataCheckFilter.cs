using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.Generic.Abstract;

namespace ServiceLayer.WebApplication.Filters
{
    public class HomePageDataCheckFilter : IAsyncActionFilter
    {
        private readonly IGenericRepository<HomePage> _genericRepository;

        public HomePageDataCheckFilter(IGenericRepository<HomePage> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //my concept allows me to have just one homepage section in a resume. So if i have one, this filter prevents to add a new one
            var aboutMe = await _genericRepository.Where(x => x.IsEdited == true).SingleOrDefaultAsync();

            if (aboutMe != null)
            {
                context.Result = new RedirectToActionResult("HomePageList", "HomePage", new { Area = "Admin" });
                return;
            }

            await next.Invoke();
            return;

        }
    }
}
