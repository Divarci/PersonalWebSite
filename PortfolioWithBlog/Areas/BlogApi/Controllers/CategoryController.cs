using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer._SharedFolder.Helpers.ModalStateHelper;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Area("BlogApi")]
    public class CategoryController : Controller
    {
        private readonly CategoryServiceApi _categoryServiceApi;

        public CategoryController(CategoryServiceApi categoryServiceApi)
        {
            _categoryServiceApi = categoryServiceApi;
        }


        public async Task<IActionResult> CategoryList()
        {
            var categoryList = await _categoryServiceApi.GetCategoryListAsync();
            return View(categoryList);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int id)
        {
            var getResult = await _categoryServiceApi.GetCategoryByIdAsync(id);
            if (getResult.Item1 != null)
            {
                return View(getResult.Item1);
            }

            return RedirectToAction("NotFound", "Error", new { Area = "BlogApi", errors = getResult.Item2.Errors });
        }

        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateVM updatedCategory)
        {
            var putResult = await _categoryServiceApi.UpdateCategoryAsync(updatedCategory);
            if (putResult.Item2 == true)
            {
                return RedirectToAction("categoryList", "Category", new { Area = "BlogApi" });
            }
            ModelState.AddModelErrorList(putResult.Item1.Errors!);
            return View();
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryAddVM newcategory)
        {
            var postResult = await _categoryServiceApi.AddCategoryAsync(newcategory);
            if(postResult.Data != null)
            {
                return RedirectToAction("categoryList", "Category", new { Area = "BlogApi" });
            }

            ModelState.AddModelErrorList(postResult.Errors!);
            return View();
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            var deleteResult = await _categoryServiceApi.DeleteCategoryAsync(id);
            if(deleteResult.Item2 == true)
            {
                return RedirectToAction("categoryList", "Category", new { Area = "BlogApi" });
            }

            ModelState.AddModelErrorList(deleteResult.Item1.Errors!);
            return RedirectToAction("NotFound", "Error", new { Area = "BlogApi", errors = deleteResult.Item1.Errors });

        }
    }
}
