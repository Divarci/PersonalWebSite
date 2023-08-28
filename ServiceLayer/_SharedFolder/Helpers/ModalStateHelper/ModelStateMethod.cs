using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ServiceLayer._SharedFolder.Helpers.ModalStateHelper
{
    public static class ModelStateMethod
    {
        //method for adding errors to model state for List<string>
        public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
        {
            errors.ForEach(x =>
            {
                modelState.AddModelError(string.Empty, x);
            });


        }
        //overload method for adding errors to model state for IEnumerable<IdentityError>
        public static void AddModelErrorList(this ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            errors.ToList().ForEach(x =>
            {
                modelState.AddModelError(string.Empty, x.Description);
            });


        }
    }
}
