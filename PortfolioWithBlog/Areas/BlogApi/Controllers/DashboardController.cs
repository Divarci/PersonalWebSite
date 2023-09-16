using CoreLayer.Enums;
using CoreLayer.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.BlogApiClient.Exceptions;
using ServiceLayer.BlogApiClient.Filters;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]
    [Area("BlogApi")]
    public class DashboardController : _BaseController<ArticleController>
    {
        private readonly ArticleServiceApi _articleServiceApi;

        public DashboardController(ArticleServiceApi articleServiceApi, IToastNotification toasty, IGenericMessages messages) : base(toasty, messages)
        {
            _articleServiceApi = articleServiceApi;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _articleServiceApi.GetAllArticleForDashboardAsync();
            return HandleResponse(response, BlogCrudType.Select);
        }

        public IActionResult Error(List<string> errors, short code)
        {
            List<ErrorVM> allowedErrors = new()
            {
               new ErrorVM { Error =new List<string> { "Id is not valid." }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Data is not found." }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Unauthorized Access" }, StatusCode = 401 },
               new ErrorVM { Error =new List<string> { "Permission Needed" }, StatusCode = 403 },
               new ErrorVM { Error =new List<string> { "Page Not Found" }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Please delete all articles related to this category!" }, StatusCode = 409 },
               new ErrorVM { Error =new List<string> { "You do not have any category to add in!" }, StatusCode = 409 },
            };


            var incomingErrorList = new ErrorVM
            {
                Error = errors,
                StatusCode = code
            };

            if (allowedErrors.Any(x => x.Error.FirstOrDefault() == incomingErrorList.Error.FirstOrDefault() && x.StatusCode == incomingErrorList.StatusCode))
            {
                return View(incomingErrorList);
            }

            return Redirect("/Home/PageNotFound");


        }
    }
}
