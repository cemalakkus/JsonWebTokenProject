using ApiKeyProject.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApiKeyProject.Attribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {

        }
    }
}
