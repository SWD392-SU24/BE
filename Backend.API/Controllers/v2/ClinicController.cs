using Asp.Versioning;
using Backend.API.Controllers.v1;
using Backend.BLL.Features.Clinics;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v2
{
    [ApiVersion(2)]
    public class ClinicController : BaseApiController
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet("get-all/clinic")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ClinicResponse>> GetAllClinics()
        {
            var clinics = await _clinicService.GetAllClinicsAsync();
            return Ok(clinics);
        }
        [HttpPost("add/clinic")]
        [ProducesResponseType(typeof(ClinicResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ClinicResponse>> AddClinic([FromBody] ClinicRequest clinicRequest)
        {
            var addedClinic = await _clinicService.AddClinicAsync(clinicRequest);
            return Ok(addedClinic);
        }

        [HttpPut("update/clinic/{clinicId}")]
        [ProducesResponseType(typeof(ClinicResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ClinicResponse>> UpdateClinic(int clinicId, [FromBody] ClinicRequest clinicRequest)
        {
            var updatedClinic = await _clinicService.UpdateClinicAsync(clinicId, clinicRequest);
            return Ok(updatedClinic);
        }
        [HttpDelete("delete/clinic/{clinicId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            await _clinicService.DeleteClinicAsync(clinicId);
            return Ok("Delete Success!");
        }

        [HttpGet("get-by-name/clinic")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<List<ClinicResponse>>> GetClinicsByName(string? clinicName)
        {
            var clinics = await _clinicService.GetClinicsByNameAsync(clinicName);
            return Ok(clinics);
        }
    }
}
