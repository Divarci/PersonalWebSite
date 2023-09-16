using CoreLayer.Enums;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.BlogApiClient.Filters;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]
    [Area("BlogApi")]
    public class ArticleController : _BaseController<ArticleController>
    {
        private readonly ArticleServiceApi _articleServiceApi;

        public ArticleController(ArticleServiceApi articleServiceApi, IToastNotification toasty, IGenericMessages messages) :base(toasty,messages)
        {
            _articleServiceApi = articleServiceApi;

        }

        public async Task<IActionResult> List()
        {
            var response = await _articleServiceApi.GetAllArticleAsync();
            return HandleResponse(response, BlogCrudType.Select);
        }
        
        [ServiceFilter(typeof(RequestToApi))]
        [HttpGet]
        public async Task<IActionResult> ArticleUpdate(int id)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _articleServiceApi.GetArticleByIdAsync(id, myClient!);
            return HandleResponse(response, BlogCrudType.Select);
        }

        [Authorize(Roles = "SuperAdmin")]
        [ServiceFilter(typeof(RequestToApi))]
        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(ArticleUpdateVM updatedArticle)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _articleServiceApi.ArticleUpdateAsync(updatedArticle, myClient!);
            return HandleResponse(response, BlogCrudType.Modify);
        }

        [ServiceFilter(typeof(RequestToApi))]
        [HttpGet]
        public async Task<IActionResult> ArticleAdd()
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var categories = await _articleServiceApi.GetCategoriesForDropDown(myClient!);
            return HandleResponse(categories, BlogCrudType.SelectSingle);

        }

        [Authorize(Roles = "SuperAdmin")]
        [ServiceFilter(typeof(RequestToApi))]
        [HttpPost]
        public async Task<IActionResult> ArticleAdd(ArticleAddVM newArticle)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _articleServiceApi.AddArticleAsync(newArticle, myClient!);
            return HandleResponse(response, BlogCrudType.Create);
        }

        [Authorize(Roles = "SuperAdmin")]
        [ServiceFilter(typeof(RequestToApi))]
        public async Task<IActionResult> ArticleDelete(int id)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _articleServiceApi.DeleteArticleAsync(id, myClient!);
            return HandleResponse(response, BlogCrudType.Delete);
        }

       

    }
}


