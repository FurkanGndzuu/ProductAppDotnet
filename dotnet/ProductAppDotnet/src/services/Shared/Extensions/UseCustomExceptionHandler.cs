using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void CustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(cfg =>
            {
                cfg.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        ErrorDTO errorDto = new ErrorDTO();

                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        if (ex is CustomException)
                        {
                            errorDto.IsShow = true;
                        }
                        else
                        {
                            errorDto.IsShow = false;
                        }

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });

            });
        }
    }
}
