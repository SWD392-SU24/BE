using Backend.BLL.Features.Users;
using Backend.BO.Commons;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class TokenController : BaseApiController
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("refresh")]
        //TODO: Create version
        //[MapToApiVersion(1)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(DetailedError))]
        public async Task<ActionResult<AuthResponse>> Refresh(TokenApiModel tokenApiModel)
        {
            var response = await _userService.RenewTokens(tokenApiModel);
            return Ok(response);
        }
    }
}
