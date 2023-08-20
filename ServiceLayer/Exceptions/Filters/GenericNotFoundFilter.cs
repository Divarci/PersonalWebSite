using CoreLayer.BaseEntity;
using EntityLayer.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RepositoryLayer.Repository.Generic.Abstract;

namespace ServiceLayer.Exceptions.Filters
{
    public class GenericNotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericNotFoundFilter(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var value = context.ActionArguments.Values.FirstOrDefault();
            var actionname = context.ActionDescriptor.DisplayName ?? string.Empty;

            //if value is null return error. On address bar it might be typed in non-digit character
            if (value == null)
            {
                var errorVMForUnknownId = new NotFoundVM();
                errorVMForUnknownId.Errors.Add($"Data {value} is invalid. Please double-check the entered information and try again.");

                context.Result = new RedirectToActionResult("ValueNotFound", "Dashboard", errorVMForUnknownId);
                return;
            }

            // if value is not null we check is it an int value or not
            bool idcheck = value is int;
            // if id is not an int than it means it is a request for a viewmodel
            if (!idcheck)
            {
                await next.Invoke();
                return;
            }

            //if id is an int. we cast it to an int. than we check is there any match with this id.
            var id = (int)value;
            var entityCheck = await _genericRepository.AnyAsync(x => x.Id == id);
            //if it is exist. no problem
            if (entityCheck)
            {
                await next.Invoke();
                return;
            }

            //if it is not data does not exist
            var errorVModel = new NotFoundVM();
            errorVModel.Errors.Add($"Data {id} is not found. Please double-check the entered information and try again.");

            context.Result = new RedirectToActionResult("ValueNotFound", "Dashboard", errorVModel);
        }
    }
}
