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

        // ---------------------------------- //
        PageList<UserDashboardReponse> GetAllUser(string? name, string? email, string? phoneNumber, string? address, int? sex, string? role, int pageNumber, int pageSize);
        Task<UserResponse?> GetUserById(Guid id);
        Task<UserResponse?> CreateUser(UserRequest userCreateRequest);
        Task<bool> UpdateUser(Guid id, UpdateUserRequest userUpdateRequest);
        Task<bool> DeleteUser(Guid id);
    }
}
