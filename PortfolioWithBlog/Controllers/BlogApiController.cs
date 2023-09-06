using CoreLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PortfolioWithBlog.Areas.BlogApi.Controllers;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Controllers
{
    public class BlogApiController : _BaseController<ArticleController>
    {
        private readonly ArticleServiceApi _articleServiceApi;

        public BlogApiController(ArticleServiceApi articleServiceApi)
        {
            _articleServiceApi = articleServiceApi;
        }

        public async Task<IActionResult> Index(short page)
        {
            var articlePagination = await _articleServiceApi.ArticlePaginationAsync(page);
            ViewBag.Count = articlePagination.Item3;
            return HandleResponse((articlePagination.Item1,articlePagination.Item2), BlogCrudType.Select);
        }
    }
}
