using CoreLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PortfolioWithBlog.Areas.BlogApi.Controllers;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Controllers
{
    public class BlogApiUiController : _BaseController<CategoryController>
    {
        private readonly CategoryServiceApi _categoryServiceApi;

        public BlogApiUiController(CategoryServiceApi categoryServiceApi, IToastNotification toasty, IGenericMessages messages) : base(toasty, messages)
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
