using APIGateway.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            this._configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext != null && httpContext.Request.Path != "/swagger/index.html")
            {
                var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!string.IsNullOrEmpty(token))
                {
                    bool isValid = await ValidateToken(token);
                    if (isValid)
                        await _next(httpContext);
                    else
                        await ReturnInvalidTokenResponse(httpContext);
                }
                else
                {
                    await ReturnInvalidTokenResponse(httpContext);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private async Task<bool> ValidateToken(string token)
        {
            var encodedToken = System.Web.HttpUtility.UrlEncode(token);
            var authUri = $"{_configuration["AuthorizationServiceEndpoint"]}Login/ValidateToken?token={encodedToken}";
            var IsValid = await HttpRequestClient.GetRequest<bool>(authUri);
            return IsValid;
        }

        private async Task ReturnInvalidTokenResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;
            await context.Response.CompleteAsync();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
