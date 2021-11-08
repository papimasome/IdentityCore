using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TemplatePrj.Models;
using TemplatePrj.Models.ViewModel;

namespace TemplatePrj.Middleware
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static void UseAdvancedExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<AdvancedExceptionHandler>();
        }
    }
    public class AdvancedExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdvancedExceptionHandler> _logger;
        private readonly IWebHostEnvironment _env;

        public AdvancedExceptionHandler(RequestDelegate next, ILogger<AdvancedExceptionHandler> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            string message = null;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["StackTrace"] = ex.StackTrace,
                        ["Exception"] = ex.Message
                    };
                    message = JsonConvert.SerializeObject(dic);
                }
                else
                {
                    message = "an error has occurred";
                }
                await WriteToReponseAsync();
            }
            async Task WriteToReponseAsync()
            {
                if (context.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started");
                var exceptionResult = new ExceptionResult(message, (int)httpStatusCode);
                var result = JsonConvert.SerializeObject(exceptionResult);
                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }
    }
}
