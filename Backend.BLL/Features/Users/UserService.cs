using Backend.BLL.Features.Auth;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using System.Security.Claims;

namespace Backend.BLL.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Authenticate(AuthRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentException("Invalid client request!");
                var user = await _unitOfWork.GetRepository<User>().GetAsync(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim()
                    && user.Password.ToLower().Trim() == user.Password.ToLower().Trim());
                if (user is null)
                    throw new KeyNotFoundException("User is not found!");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                // Store refresh token and its expired time into database
                _unitOfWork.GetRepository<User>().Update(user);
                await _unitOfWork.CommitAsync();

                var response = new AuthResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiredAt = user.RefreshTokenExpiryTime
                };
                return response;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        
        public async Task<AuthResponse> RenewTokens(TokenApiModel tokenApiModel)
        {
            try
            {
                if (tokenApiModel is null)
                    throw new ArgumentException("Invalid client request!");
                var accessToken = tokenApiModel.AccessToken;
                var refreshToken = tokenApiModel.RefreshToken;

                var principal = _tokenService.GetPrincipalFromAccessToken(accessToken ?? string.Empty);
                // Retrieve the email claim in payload
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;

                var user = await _unitOfWork.GetRepository<User>().GetAsync(user => user.Email == email);
                if (user is null)
                    throw new KeyNotFoundException("User is not found!");

                var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
                var newRefreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                _unitOfWork.GetRepository<User>().Update(user);
                await _unitOfWork.CommitAsync();
                var response = new AuthResponse
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    ExpiredAt = user.RefreshTokenExpiryTime,
                };
                return response;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        
        public async Task<bool> Revoke(TokenApiModel tokenApiModel)
        {
            var result = false;
            try
            {
                var principal = _tokenService.GetPrincipalFromAccessToken(tokenApiModel.AccessToken ?? string.Empty);
                var emailClaim = principal.FindFirst(ClaimTypes.Email)?.Value;

                var user = await _unitOfWork.GetRepository<User>()
                    .GetAsync(u => u.Email == emailClaim);
                if (user is null)
                    throw new KeyNotFoundException("User does not exist!");

                // Compare the existed refresh token with requested refresh token
                // If it matches, clear the data of refresh token & time
                if (tokenApiModel.RefreshToken == user.RefreshToken)
                {
                    user.RefreshToken = null;
                    user.RefreshTokenExpiryTime = DateTime.MinValue;

                    _unitOfWork.GetRepository<User>().Update(user);
                    await _unitOfWork.CommitAsync();
                    result = true;
                }
                else throw new Exception("The refresh token does not match!");
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            return result;
        }
    }
}
