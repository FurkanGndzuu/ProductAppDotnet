using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Extensions
{
    public static class UseCustomValidationHandler
    {
        public static void CustomValidationHandler(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                    ErrorDTO errorDto = new ErrorDTO();

                    errorDto.Errors.AddRange(errors);

                    errorDto.Status = 400;
                    errorDto.IsShow = true;

                    return new BadRequestObjectResult(errorDto);
                };
            });
        }
    }
}
