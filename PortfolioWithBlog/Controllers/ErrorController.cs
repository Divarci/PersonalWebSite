using CoreLayer.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.BlogApiClient.Exceptions;
using ServiceLayer.WebApplication.Exceptions;

namespace PortfolioWithBlog.Controllers
{

    public class ErrorController : Controller
    {
        private readonly IToastNotification _toasty;

        public ErrorController(IToastNotification toasty)
        {
            _toasty = toasty;
        }

        //Exception Pages
        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult GeneralException()
        {

            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails.Error;

            if (exception.InnerException is SqlException sqlException && sqlException.Number == 547)
            {
                return View(new ErrorVM("Please delete all relevant data first!", 400));
            }

            if (exception is ClientSideExceptions)
            {
                return View(new ErrorVM(exception.Message, 400));
            }

            if (exception is BlogApiExceptions)
            {
                return View(new ErrorVM(exception.Message, 400));
            }

            return View(new ErrorVM("Unhandled Error has been occured!", 500));
        }

        public IActionResult ApiError(List<string> errors, short code)
        {
            List<ErrorVM> allowedErrors = new()
            {
               new ErrorVM { Error =new List<string> { "Id is not valid." }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Data is not found." }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Unauthorized Access" }, StatusCode = 401 },
               new ErrorVM { Error =new List<string> { "Permission Needed" }, StatusCode = 403 },
               new ErrorVM { Error =new List<string> { "Page Not Found" }, StatusCode = 404 },
               new ErrorVM { Error =new List<string> { "Please delete all articles related to this category!" }, StatusCode = 409 },
               new ErrorVM { Error =new List<string> { "You do not have any category to add in!" }, StatusCode = 409 },
            };


            var incomingErrorList = new ErrorVM
            {
                Error = errors,
                StatusCode = code
            };

            if (allowedErrors.Any(x => x.Error.FirstOrDefault() == incomingErrorList.Error.FirstOrDefault() && x.StatusCode == incomingErrorList.StatusCode))
            {
                return View(incomingErrorList);
            }

            return Redirect("/Error/PageNotFound");


        }
    }
}
