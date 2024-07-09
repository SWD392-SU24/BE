using Backend.BLL.Features.Users;
using Backend.BO.Commons;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Backend.API.Controllers.v1
{
    public class TokenController : BaseApiController
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Generate new tokens when access token is expired
        /// </summary>
        /// <param name="tokenApiModel"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        //TODO: Create version
        //[MapToApiVersion(1)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> Refresh(TokenApiModel tokenApiModel)
        {
            var result = await _userService.RenewTokens(tokenApiModel);
            var response = new ResponseModel<AuthResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success.",
                Response = result
            };
            return Ok(response);
        }
    }
}
