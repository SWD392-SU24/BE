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
        
        [HttpPost("sign-up/customer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForCustomer(CustomerSignupRequest customer)
        {
            var result = await _userService.SignupForCustomer(customer);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Register successfully!",
                    response: null
                );
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("sign-up/clinic-owner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForClinicOwner(ClinicOwnerSignupRequest clinicOwner)
        {
            var result = await _userService.SignupForClinicOwner(clinicOwner);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Register successfully!",
                    response: null
                );
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> Signin(AuthRequest authRequest)
        {
            var result = await _userService.Authenticate(authRequest);
            var response = new ResponseModel<AuthResponse>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Sign in successfully!",
                response: result
            );
            return Ok(response);
        }

        [HttpPost("dentist/sign-in")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> SigninForDentist(AuthRequest authRequest)
        {
            var result = await _userService.AuthenticateForDentist(authRequest);
            var response = new ResponseModel<AuthResponse>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Sign in successfully!",
                response: result
            );
            return Ok(response);
        }

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
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Sign out successfully!",
                    response: null
                );
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("system-admin/accounts")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<UserDashboardReponse>>>> GetAccountsInSystem(string? name, string? role, string? address)
        {
            var accounts = await _userService.GetAccounts(name, role, address);
            var response = new ResponseModel<IList<UserDashboardReponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "List of account(s)",
                response: accounts
            );
            return Ok(response);
        }

        [HttpGet("system-admin/accounts/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            var response = new ResponseModel<UserResponse>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Information of user",
                response: user
            );
            return Ok(response);
        }

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
            var response = new ResponseModel<string>(
                statusCode: (int)HttpStatusCode.NoContent,
                message: "Update account successfully.",
                response: null
            );
            return Ok(response);
        }

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
            var response = new ResponseModel<string>(
                statusCode: (int)HttpStatusCode.NoContent,
                message: "Delete account successfully.",
                response: null
            );
            return Ok(response);
        }

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
            var response = new ResponseModel<string>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Update customer successfully!",
                response: null
            );
            return Ok(response);
        }
        
    }
}
