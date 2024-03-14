using ApiKeyProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiKeyProject.Filters
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IApiKeyValidation _apiKeyValidation;
        public ApiKeyAuthFilter(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userApiKey = context.HttpContext.Request.Headers["ApiKey"].ToString();
            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                context.Result = new BadRequestResult();
                return;
            }
            if (!_apiKeyValidation.IsValidApiKey(userApiKey))
                context.Result = new UnauthorizedResult();
        }
    }
}
