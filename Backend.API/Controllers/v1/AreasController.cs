using Backend.BLL.Features.Areas;
using Backend.BO.Commons;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class AreasController : BaseApiController
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet("areas")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<AreaResponse>>>> GetAreas()
        {
            var areas = await _areaService.GetAreas();
            var response = new ResponseModel<IList<AreaResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "List of areas",
                response: areas
            );
            return Ok(response);
        }
    }
}
