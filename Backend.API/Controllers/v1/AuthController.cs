using Backend.BLL.Features.Users;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class AuthController : BaseApiController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
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
    }
}
