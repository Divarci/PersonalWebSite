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

        
    }
}
