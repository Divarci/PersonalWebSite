using CoreLayer.Enums;
using CoreLayer.ResponseModel;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer._SharedFolder.Helpers.ModalStateHelper;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.BlogApiClient.Exceptions;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    public class _BaseController<ControllerName> : Controller where ControllerName : Controller
    {
        protected readonly IToastNotification _toasty;
        protected readonly IGenericMessages _messages;

        public _BaseController(IToastNotification toasty, IGenericMessages messages) 
        {
            _toasty = toasty;
            _messages = messages;
        }

        public IActionResult HandleResponse<TViewModel>((CustomResponseVM<TViewModel>, short) response, BlogCrudType crudType) where TViewModel : class
        {
            var controllerFullName = typeof(ControllerName).Name;
            var controllerName = controllerFullName.Replace("Controller", "");

            var statusCode = response.Item2;

            if (statusCode == ((short)crudType))
            {
                if (statusCode == 200)
                {
                    return View(response.Item1.Data);
                }

                if (crudType == BlogCrudType.Create )
                {
                    _toasty.AddSuccessToastMessage(_messages.Add("Article"), new ToastrOptions { Title = "Congratulations!" });
                }
               
                if (crudType == BlogCrudType.Modify)
                {
                    _toasty.AddInfoToastMessage(_messages.Update("Article"), new ToastrOptions { Title = "Congratulations!" });
                }

                if (crudType == BlogCrudType.Delete)
                {
                    _toasty.AddWarningToastMessage(_messages.Delete("Article"), new ToastrOptions { Title = "Congratulations!" });
                }

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
