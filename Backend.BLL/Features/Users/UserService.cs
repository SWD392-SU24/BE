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
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                // store refresh token and its expired time into database
                _unitOfWork.GetRepository<User>().Update(user);
                await _unitOfWork.CommitAsync();

                var response = new AuthResponse
                {
                    Message = "Login successfully!",
                    Token = accessToken,
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

                var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken ?? string.Empty);
                // retrieve the email claim in payload
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
                    Message = "Renew tokens successfully!",
                    Token = newAccessToken,
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

        public async Task<bool> Signout(string email)
        {
            var result = false;
            try
            {
                var user = await _unitOfWork.GetRepository<User>().GetAsync(user => user.Email == email);
                if (user is null)
                    throw new KeyNotFoundException("User is not found!");
                // Clear data of these fields when user signed out
                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = DateTime.MinValue;

                _unitOfWork.GetRepository<User>().Update(user);
                await _unitOfWork.CommitAsync();
                result = true;
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
