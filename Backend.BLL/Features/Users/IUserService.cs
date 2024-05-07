using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Users
{
    public interface IUserService
    {
        Task<AuthResponse> Authenticate(AuthRequest request);

        Task<AuthResponse> RenewTokens(TokenApiModel tokenApiModel);

        Task<bool> Signout(string email);
    }
}
