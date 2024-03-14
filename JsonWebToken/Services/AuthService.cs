using JsonWebToken.Dtos;
using JsonWebToken.Interfaces;

namespace JsonWebToken.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserName == "test" && request.Password == "123456")
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = request.UserName });

                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
            }

            return response;
        }
    }
}
