using Microsoft.AspNetCore.Mvc;
using Backend.BO.Commons;
using Backend.BLL.Features.Users;
using Backend.BO.Payloads.Requests;
using System.Net;
using Backend.BO.Payloads.Responses;

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

        //[HttpGet("accounts")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesErrorResponseType(typeof(ResponseModel<string>))]
        //public IActionResult GetAllUsers(string? name, string? email, string? phoneNumber, string? address, int? sex, string? role, int pageNumber = 1, int pageSize = 5)
        //{
        //    var result = _userService.GetAllUser(name, email, phoneNumber, address, sex, role, pageNumber, pageSize);
        //    return Ok(result);
        //}

        //public async Task<ActionResult<ResponseModel<IList<UserDashboardReponse>>>> GetAccounts(string? name, string? address, string? role)
        //{
        //    var accounts = await _userService.GetAccounts(name, role, address);
        //    var response = new ResponseModel<IList<UserDashboardReponse>>(
        //        statusCode: (int)HttpStatusCode.OK,
        //        message: "List of accounts",
        //        response: accounts
        //    );
        //    return Ok(response);
        //}

        //[HttpGet("accounts/{id}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<ResponseModel<UserResponse>>> GetUser(Guid id)
        //{
        //    var user = await _userService.GetUserById(id);
        //    var response = new ResponseModel<UserResponse>(
        //        statusCode: (int)HttpStatusCode.OK,
        //        message: "User",
        //        response: user
        //    );
        //    return Ok(user);
        //}

        //// POST: api/v1/Users
        //[HttpPost("account")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<ActionResult<ResponseModel<string>>> CreateUser(UserRequest userCreateRequest)
        //{
        //    var userResponse = await _userService.CreateUser(userCreateRequest);
        //    if (userResponse == null)
        //    {
        //        return BadRequest();
        //    }
        //    var response = new ResponseModel<string>(
        //        statusCode: (int)HttpStatusCode.OK,
        //        message: "Create account successfully!",
        //        response: null
        //    );
        //    return Ok(response);
        //}

        //// PUT: api/v1/Users/5
        //[HttpPut("account/{id}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<ResponseModel<string>>> UpdateUser(Guid id, UpdateUserRequest userUpdateRequest)
        //{
        //    var result = await _userService.UpdateUser(id, userUpdateRequest);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    var response = new ResponseModel<string>(
        //        statusCode: (int)HttpStatusCode.NoContent,
        //        message: "Update account successfully.",
        //        response: null
        //    );
        //    return Ok(response);
        //}

        //// DELETE: api/v1/Users/5
        //[HttpDelete("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<ResponseModel<string>>> DeleteUser(Guid id)
        //{
        //    var result = await _userService.DeleteUser(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    var response = new ResponseModel<string>(
        //        statusCode: (int)HttpStatusCode.NoContent,
        //        message: "Delete account successfully.",
        //        response: null
        //    );
        //    return Ok(response);
        //}
    }
}
