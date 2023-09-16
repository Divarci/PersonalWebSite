using CoreLayer.Enums;
using CoreLayer.Errors;
using CoreLayer.ResponseModel;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer._SharedFolder.Helpers.ModalStateHelper;
using ServiceLayer.BlogApiClient.Exceptions;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    public class _BaseController<ControllerName> : Controller where ControllerName : Controller
    {
        public IActionResult HandleResponse<TViewModel>((CustomResponseVM<TViewModel>, short) response, BlogCrudType crudType) where TViewModel : class 
        {
            var controllerFullName = typeof(ControllerName).Name;
            var controllerName = controllerFullName.Replace("Controller", "");

            var statusCode = response.Item2;

            if (statusCode == ((short)crudType))
            {
                if (statusCode == 200 ) return View(response.Item1.Data);
                
                return RedirectToAction("List", controllerName, new { Area = "BlogApi" });
            }

            if (statusCode == 200 && ((short)crudType) == 202)
            {
                return View(new ArticleAddVM
                {
                    Categories = response.Item1.Data as List<CategoryListVM>
                });
            }

            if (statusCode == 400)
            {
                ModelState.AddModelErrorList(response.Item1.Errors!);
                return View(response.Item1.Data);
            }
            
            if (statusCode == 500)
            {
                throw new BlogApiExceptions(response.Item1.Errors!.FirstOrDefault());
            }

            return RedirectToAction("Error", "Dashboard", new { Area = "BlogApi", errors = response.Item1.Errors, code = statusCode });
        }
    }
}
