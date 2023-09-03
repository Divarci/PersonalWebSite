using CoreLayer.Enums;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.BlogApiClient.Filters;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [ServiceFilter(typeof(RequestToApi))]
    [Area("BlogApi")]
    public class CategoryController : _BaseController<CategoryController>
    {
        private readonly CategoryServiceApi _categoryServiceApi;

        public CategoryController(CategoryServiceApi categoryServiceApi)
        {
            _categoryServiceApi = categoryServiceApi;
        }
     
        public async Task<IActionResult> List()
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _categoryServiceApi.GetCategoryListAsync(myClient!);
            return HandleResponse(response, BlogCrudType.Select);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int id)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _categoryServiceApi.GetCategoryByIdAsync(id, myClient!);
            return HandleResponse(response, BlogCrudType.Select);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateVM updatedCategory)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _categoryServiceApi.UpdateCategoryAsync(updatedCategory, myClient!);
            return HandleResponse(response, BlogCrudType.Update);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryAddVM newcategory)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _categoryServiceApi.AddCategoryAsync(newcategory, myClient!);
            return HandleResponse(response, BlogCrudType.Create);
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            var myClient = HttpContext.Items["Token"] as HttpClient;
            var response = await _categoryServiceApi.DeleteCategoryAsync(id, myClient!);
            return HandleResponse(response, BlogCrudType.Delete);
        }
    }
}
