using Jazani.Api.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsModelState = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage))
                    .ToList();

                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Message = "Ingrese todos los campos requeridos";
                errorResponse.Errors = new List<ErrorValidationModel>();

                errorsModelState.ForEach(error =>
                {
                    error.Value?.ToList().ForEach(message =>
                    {
                        errorResponse.Errors.Add(new ErrorValidationModel()
                        {
                            FieldName = error.Key,
                            Message = message
                        });
                    });
                });

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }


            await next();
        }
    }
}
