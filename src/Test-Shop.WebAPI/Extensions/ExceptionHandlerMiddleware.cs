using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Test_Shop.Shared.Models.Responses;

namespace Test_Shop.WebAPI.Extensions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = new BaseResponse();

                switch (exception)
                {
                    case ValidationException validationException:
                        response = new BaseResponse { Errors = validationException.Errors.Select(e => e.ErrorMessage) };
                        break;
                    //case ApiException apiException:
                    //    response = new BaseResponse { Errors = new[] { apiException.Message } };
                    //    break;
                    case { } baseException:
                        response = new BaseResponse { Errors = new[] { baseException.Message } };
                        break;
                }

                var result = JsonConvert.SerializeObject(response);

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }
        }
    }
}
