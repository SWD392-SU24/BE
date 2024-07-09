using Microsoft.AspNetCore.Mvc;
using Backend.BO.Commons;
using Backend.BLL.Features.Users;
using Backend.BO.Payloads.Requests;
using System.Net;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Authorization;

namespace Backend.API.Controllers.v1
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Sign up for customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("sign-up/customer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForCustomer(CustomerSignupRequest customer)
        {
            var result = await _userService.SignupForCustomer(customer);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Register successfully!",
                    Response = null
                };
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Sign up for clinic owner
        /// </summary>
        /// <param name="clinicOwner"></param>
        /// <returns></returns>
        [HttpPost("sign-up/clinic-owner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForClinicOwner(ClinicOwnerSignupRequest clinicOwner)
        {
            var result = await _userService.SignupForClinicOwner(clinicOwner);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Register successfully!",
                    Response = null
                };
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [HttpPost("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> Signin(AuthRequest authRequest)
        {
            var result = await _userService.Authenticate(authRequest);
            var response = new ResponseModel<AuthResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Sign in successfully!",
                Response = result
            };
            return Ok(response);
        }

        /// <summary>
        /// Sign in for dentist
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [HttpPost("dentist/sign-in")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> SigninForDentist(AuthRequest authRequest)
        {
            var result = await _userService.AuthenticateForDentist(authRequest);
            var response = new ResponseModel<AuthResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Sign in successfully!",
                Response = result
            };
            return Ok(response);
        }

        /// <summary>
        /// Sign out
        /// </summary>
        /// <param name="tokenApiModel"></param>
        /// <returns></returns>
        [HttpPost("sign-out")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> Signout(TokenApiModel tokenApiModel)
        {
            var result = await _userService.Revoke(tokenApiModel);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Sign out successfully!",
                    Response = null
                };
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get account in system (system admin role)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet("system-admin/accounts")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<UserDashboardReponse>>>> GetAccountsInSystem(string? name, string? role, string? address)
        {
            var accounts = await _userService.GetAccounts(name, role, address);
            var response = new ResponseModel<IList<UserDashboardReponse>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of account(s)",
                Response = accounts
            };
            return Ok(response);
        }

        /// <summary>
        /// Get detailed information of an account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("system-admin/accounts/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            var response = new ResponseModel<UserResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Information of user",
                Response = user
            };
            return Ok(response);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut("system-admin/account/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> UpdateUser(Guid id, UpdateUserRequest userUpdateRequest)
        {
            var result = await _userService.UpdateUser(id, userUpdateRequest);
            if (!result)
            {
                return NotFound();
            }
            var response = new ResponseModel<string>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Update account successfully.",
                Response = null
            };
            return Ok(response);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("system-admin/account/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            var response = new ResponseModel<string>
            {
                StatusCode = (int)HttpStatusCode.NoContent,
                Message = "Delete account successfully.",
                Response = null
            };
            return Ok(response);
        }

        /// <summary>
        /// Update customer's information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("customer/account/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> UpdateCustomerInfo(Guid id, UpdateCustomerRequest request)
        {
            var result = await _userService.UpdateCustomerInformation(id, request);
            if (!result)
            {
                return NotFound();
            }
            var response = new ResponseModel<string>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Update customer successfully!",
                Response = null
            };
            return Ok(response);
        }
        
    }
}
