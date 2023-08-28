using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer._SharedFolder.Helpers.ModalStateHelper;
using ServiceLayer.BlogApiClient.Services;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Area("BlogApi")]
    public class ArticleController : Controller
    {
        private readonly ArticleServiceApi _articleServiceApi;

        public ArticleController(ArticleServiceApi articleServiceApi)
        {
            _articleServiceApi = articleServiceApi;
        }

        public async Task<IActionResult> ArticleList()
        {
            var articleList = await _articleServiceApi.GetAllArticleAsync();
            return View(articleList);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleUpdate(int id)
        {
            var getResult = await _articleServiceApi.GetArticleByIdAsync(id);
            if (getResult.Item1 != null)
            {
                return View(getResult.Item1);
            }

            return RedirectToAction("NotFound", "Error", new { Area = "BlogApi", errors = getResult.Item2.Errors });
        }
        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(ArticleUpdateVM updatedArticle)
        {
            var putResult = await _articleServiceApi.ArticleUpdateAsync(updatedArticle);
            if(putResult.Item2 == null)
            {
                return RedirectToAction("ArticleList", "Article", new { Area = "BlogApi" });
            }

            ModelState.AddModelErrorList(putResult.Item1.Errors!);
            return View(new ArticleUpdateVM { Categories = putResult.Item2 });
        }

        [HttpGet]
        public async Task<IActionResult> ArticleAdd()
        {
            var categories = await _articleServiceApi.GetCategoriesForDropDown();
            return View(new ArticleAddVM { Categories = categories });
        }
        [HttpPost]
        public async Task<IActionResult> ArticleAdd(ArticleAddVM newArticle)
        {
            var postResult = await _articleServiceApi.AddArticleAsync(newArticle);
            if (postResult.Errors == null)
            {
                return RedirectToAction("ArticleList", "Article", new { Area = "BlogApi" });
            }

            ModelState.AddModelErrorList(postResult.Errors);    
            return View(postResult.Data);

        }

        public async Task<IActionResult> ArticleDelete(int id)
        {
            var deleteResult = await _articleServiceApi.DeleteArticleAsync(id);
            if(deleteResult.Item2)
            {
                return RedirectToAction("ArticleList", "Article", new { Area = "BlogApi" });
            }

            ModelState.AddModelErrorList(deleteResult.Item1.Errors!);
            return RedirectToAction("NotFound", "Error", new { Area = "BlogApi", errors = deleteResult.Item1.Errors });

        }
    }

}
