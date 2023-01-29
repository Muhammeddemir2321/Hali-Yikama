using Hali.Core.DTOs;
using Hali.Shared.DTOs;
using Hali.Shared.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hali.Shared.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    if (exceptionFeature.Error != null)
                    {
                        ErrorDto errorDto = null;

                        if (exceptionFeature.Error is NotFoundException)
                        {
                            errorDto = new ErrorDto(exceptionFeature.Error.Message, true);
                        }
                        else
                        {
                            errorDto = new ErrorDto(exceptionFeature.Error.Message, false);
                        }

                        var responce = ResponseDto<NoContent>.Fail(errorDto, statusCode);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(responce));
                    }
                });
            });
        }
    }
}
