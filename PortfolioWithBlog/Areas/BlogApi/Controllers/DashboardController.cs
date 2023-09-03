using CoreLayer.Errors;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWithBlog.Areas.BlogApi.Controllers
{
    [Area("BlogApi")]
    public class DashboardController : Controller
    {
        private (short,string) ExceptionMessageAndCodeRegenerator(List<string> message)
        {
            string wholeQueryString = message.FirstOrDefault()!;
            string keyString = "?";
            int index = wholeQueryString.IndexOf(keyString);
            short statusCode = Convert.ToInt16(wholeQueryString.Substring(index + 1));
            string error = wholeQueryString.Substring(0, index);
            return(statusCode,error);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(List<string> errors, short code)
        {
            if (code == 0) 
            {
                var error = ExceptionMessageAndCodeRegenerator(errors);

                var errorList = new ErrorVM
                {
                    Error = new List<string> { error.Item2},
                    StatusCode = error.Item1    
                };
                return View(errorList);
            }
            else
            {
                var errorList = new ErrorVM
                {
                    Error = errors,
                    StatusCode = code
                };
                return View(errorList);
            }
           

            
        }
    }
}
