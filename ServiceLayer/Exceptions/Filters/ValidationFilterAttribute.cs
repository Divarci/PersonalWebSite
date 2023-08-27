//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace ServiceLayer.Exceptions.Filters
//{
//    public class ValidationFilterAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            if(!context.ModelState.IsValid)
//            {
//                var eroors = context.ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
//                context.Result =new RedirectToActionResult()
//            }
//            base.OnActionExecuting(context);
//        }
//    }
//}
