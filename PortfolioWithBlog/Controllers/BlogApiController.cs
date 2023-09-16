using CoreLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PortfolioWithBlog.Areas.BlogApi.Controllers;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Controllers
{
    public class BlogApiController : _BaseController<CategoryController>
    {
        private readonly CategoryServiceApi _categoryServiceApi;

        public BlogApiController(CategoryServiceApi categoryServiceApi)
        {
            _categoryServiceApi = categoryServiceApi;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServiceApi.GetCategoryListAsync();
            return HandleResponse(categories, BlogCrudType.Select);
        }
    }
}
