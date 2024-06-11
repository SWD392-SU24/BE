using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Users
{
    public interface IUserService
    {
        Task<AuthResponse> Authenticate(AuthRequest request);

        Task<AuthResponse> RenewTokens(TokenApiModel tokenApiModel);

        /// <summary>
        /// Revoke the specified token.
        /// </summary>
        /// <param name="tokenApiModel">The token to revoke.</param>
        /// <returns>A boolean indicating whether the token was successfully revoked.</returns>
        Task<bool> Revoke(TokenApiModel tokenApiModel);

        Task<bool> SignupForCustomer(CustomerSignupRequest request);

        Task<bool> SignupForClinicOwner(ClinicOwnerSignupRequest request);
    }
}
