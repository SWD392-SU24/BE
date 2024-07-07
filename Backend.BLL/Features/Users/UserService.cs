using AutoMapper;
using Backend.BLL.Features.Auth;
using Backend.BLL.Validations;
using Backend.BO.Commons;
using Backend.BO.Constants;
using Backend.BO.Entities;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Backend.BLL.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly string _citizenIdPattern = @"^\d{12}$";

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthResponse> Authenticate(AuthRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentException("Invalid client request!");
                var user = await _unitOfWork.GetRepository<User>().GetAsync(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim()
                    && user.Password.ToLower().Trim() == request.Password.ToLower().Trim());
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

        public async Task<bool> SignupForClinicOwner(ClinicOwnerSignupRequest request)
        {
            var result = false;
            try
            {
                if (string.IsNullOrEmpty(request.Email))
                    throw new ArgumentException("Email is empty!");
                if (string.IsNullOrEmpty(request.FirstName))
                    throw new ArgumentException("First name is empty!");
                if (string.IsNullOrEmpty(request.LastName))
                    throw new ArgumentException("Last name is empty!");
                if (string.IsNullOrEmpty(request.CitizenId))
                    throw new ArgumentException("Citizen id is empty!");
                if (Regex.IsMatch(request.CitizenId, _citizenIdPattern))
                    throw new ArgumentException("Invalid citizen id!");
                if (string.IsNullOrEmpty(request.Password))
                    throw new ArgumentException("Password is empty!");
                if (string.IsNullOrEmpty(request.ConfirmedPassword))
                    throw new ArgumentException("Password must be provided to confirm!");

                if (request.Password != request.ConfirmedPassword)
                    throw new ArgumentException("Passwords do not match!");
                var emailDuplicate = await _unitOfWork.GetRepository<User>().GetAsync(u => u.Email == request.Email);
                if (emailDuplicate is not null)
                    throw new ArgumentException("Email has already existed!");
                var clinicOwner = _mapper.Map<User>(request);
                _unitOfWork.GetRepository<User>().Add(clinicOwner);
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

        public async Task<bool> SignupForCustomer(CustomerSignupRequest request)
        {
            var result = false;
            try
            {
                if (string.IsNullOrEmpty(request.Email))
                    throw new ArgumentException("Email is empty!");
                if (string.IsNullOrEmpty(request.FirstName))
                    throw new ArgumentException("First name is empty!");
                if (string.IsNullOrEmpty(request.LastName))
                    throw new ArgumentException("Last name is empty!");
                if (string.IsNullOrEmpty(request.Password))
                    throw new ArgumentException("Password is empty!");
                if (string.IsNullOrEmpty(request.ConfirmedPassword))
                    throw new ArgumentException("Password must be provided to confirm!");

                if (request.Password != request.ConfirmedPassword)
                    throw new ArgumentException("Passwords do not match!");
                // check email duplication
                var emailDuplicate = await _unitOfWork.GetRepository<User>().GetAsync(u => u.Email == request.Email);
                if (emailDuplicate is not null)
                    throw new ArgumentException("Email has already existed!");
                var customer = _mapper.Map<User>(request);
                _unitOfWork.GetRepository<User>().Add(customer);
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

        public PageList<UserDashboardReponse> GetAllUser(string? name, string? email, string? phoneNumber, string? address, 
            int? sex, string? role, int pageNumber = 1, int pageSize = 5)
        {
            var usersQuery = _unitOfWork.GetUserRepository().GetAllUser(name, email, phoneNumber, address, sex, role);
            var userPageList = PageList<User>.ToPagedList(usersQuery, pageNumber, pageSize);
            return _mapper.Map<PageList<UserDashboardReponse>>(userPageList);
        }

        public async Task<UserResponse?> GetUserById(Guid id)
        {
            IUserRepository userRepository = _unitOfWork.GetUserRepository();
            try
            {
                var user = await userRepository
                    .GetAll()
                    .Where(u => u.Id == id && (u.Role == UserRole.ClinicOwner || u.Role == UserRole.Customer))
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new KeyNotFoundException("User not found");
                }
                var userResponse = _mapper.Map<UserResponse>(user);
                return userResponse;
            }
            catch
            {
                throw;
            }
        }

        public Task<UserResponse?> CreateUser(UserRequest userCreateRequest)
        {
            throw new NotImplementedException();
            //IUserRepository userRepository = _unitOfWork.GetUserRepository();
            //try
            //{
            //    var user = _mapper.Map<User>(userCreateRequest);
            //    UserValidation.ValidationUserRequest(user);
            //    await userRepository.AddAsync(user);
            //    await _unitOfWork.CommitAsync();
            //    return _mapper.Map<UserResponse>(user);
            //}
            //catch (Exception ex)
            //{
            //    _unitOfWork.Rollback();
            //    throw new Exception(ex.Message);
            //}
        }

        public async Task<bool> UpdateUser(Guid id, UpdateUserRequest userUpdateRequest)
        {
            IUserRepository userRepository = _unitOfWork.GetUserRepository();
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                if (user == null) return false;
                _mapper.Map(userUpdateRequest, user);
                userRepository.Update(user);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            IUserRepository userRepository = _unitOfWork.GetUserRepository();
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                if (user == null) return false;
                userRepository.Delete(user);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<UserDashboardReponse>> GetAccounts(string? name, string? role, string? address)
        {
            try
            {
                var userRepository = _unitOfWork.GetRepository<User>();
                var accounts = await userRepository.GetAll()
                    .Where(u => u.Role == UserRole.ClinicOwner || u.Role == UserRole.Customer)
                    .AsNoTracking()
                    .ToListAsync();

                if (!accounts.Any())
                    throw new InvalidOperationException("No data for accounts!");

                if (!string.IsNullOrEmpty(name))
                {
                    accounts = accounts.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name))
                        .ToList();
                }
                if (!string.IsNullOrEmpty(address))
                {
                    accounts = accounts.Where(x => x.Address.Contains(address))
                        .ToList();
                }
                if (!string.IsNullOrEmpty(role))
                {
                    accounts = accounts.Where(x => x.Role.Contains(role))
                        .ToList();
                }
                var response = _mapper.Map<IList<UserDashboardReponse>>(accounts);
                if (!response.Any())
                    throw new InvalidOperationException("No data for accounts!");

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AuthResponse> AuthenticateForDentist(AuthRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentException("Invalid client request!");
                var user = await _unitOfWork.GetRepository<Dentist>().GetAsync(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim()
                    && user.Password.ToLower().Trim() == request.Password.ToLower().Trim());
                if (user is null)
                    throw new KeyNotFoundException("User is not found!");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, UserRole.Dentist)
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                // Store refresh token and its expired time into database
                _unitOfWork.GetRepository<Dentist>().Update(user);
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

        public async Task<bool> UpdateCustomerInformation(Guid id, UpdateCustomerRequest request)
        {
            var result = false;
            try
            {
                IUserRepository userRepository = _unitOfWork.GetUserRepository();

                var customer = await userRepository.GetAll()
                    .Where(u => u.Id == id && u.Role == UserRole.Customer)
                    .FirstOrDefaultAsync();
                if (customer is null)
                    throw new KeyNotFoundException("Customer does not exist!");
                var updatedCustomer = _mapper.Map(request, customer);
                
                userRepository.Update(updatedCustomer);
                await _unitOfWork.CommitAsync();
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
