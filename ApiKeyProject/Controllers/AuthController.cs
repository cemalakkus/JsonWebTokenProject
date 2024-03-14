using ApiKeyProject.Attribute;
using ApiKeyProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;

namespace ApiKeyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        public AuthController(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        [HttpGet]
        public IActionResult AuthenticateWithQueryParams(string paramsApiKey)
        {
            if (string.IsNullOrWhiteSpace(paramsApiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(paramsApiKey);

            if (!isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult AuthenticateWithBody([FromBody] RequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ApiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(model.ApiKey);

            if (!isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpGet("header")]
        public IActionResult AuthenticateVithHeader()
        {
            string? apiKey = Request.Headers["ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if (!isValid)
                return Unauthorized();

            return Ok();
        }

        public class RequestModel
        {
            public string? ApiKey { get; set; }
        }

        [HttpGet]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
        
        [HttpGet("all")]
        [Authorize(Policy = "ApiKeyPolicy")]
        public IActionResult GetProducts()
        {
            return Ok();
        }
    }
}
