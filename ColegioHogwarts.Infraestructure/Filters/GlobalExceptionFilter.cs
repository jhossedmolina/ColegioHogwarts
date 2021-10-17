using ColegioHogwarts.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ColegioHogwarts.Infraestructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType()== typeof(CandidateException))
            {
                var exception = (CandidateException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad request",
                    Detail = exception.Message
                };

                var json = new
                {
                    error = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
