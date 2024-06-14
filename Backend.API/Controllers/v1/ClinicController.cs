using Backend.BLL.Features.Clinics;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class ClinicController : BaseApiController
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpPost("clinics")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<ClinicResponse>>> AddClinic([FromBody] ClinicRequest clinicRequest)
        {
            var addedClinic = await _clinicService.AddClinicAsync(clinicRequest);
            return Ok(addedClinic);
        }

        [HttpPut("clinics/{clinicId}")]
        [ProducesResponseType(typeof(ClinicResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<ClinicResponse>>> UpdateClinic(int clinicId, [FromBody] ClinicRequest clinicRequest)
        {
            var updatedClinic = await _clinicService.UpdateClinicAsync(clinicId, clinicRequest);
            return Ok(updatedClinic);
        }
        [HttpDelete("clinics/{clinicId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> DeleteClinic(int clinicId)
        {
            await _clinicService.DeleteClinicAsync(clinicId);
            return Ok("Delete Success!");
        }

        [HttpGet("clinics/{areaId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<List<ClinicResponse>>>> GetClinicsByName(string? clinicName, int areaId)
        {
            var clinics = await _clinicService.GetClinicsByNameAsync(clinicName, areaId);
            return Ok(clinics);
        }

        [HttpGet("clinics/{ownerId}/owner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<List<ClinicResponse>>>> GetAllClinicsByOwnerId(string ownerId, int? areaId = null, short? clinicState = null)
        {
            var clinics = await _clinicService.GetAllClinicsByOwnerIdAsync(ownerId, areaId, clinicState);

            var response = new ResponseModel<List<ClinicResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Clinics retrieved successfully",
                response: clinics
            );
            return Ok(response);
        }

        [HttpGet("clinic/{id}/feedback")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<IList<ClinicFeedbackResponse>>> GetFeedbackOfAClinic(int id, DateTime? fromDate, DateTime? toDate)
        {            
            var clinics = await _clinicService.GetFeedbackOfAClinic(id, fromDate, toDate);

            var response = new ResponseModel<IList<ClinicFeedbackResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Data retrival success!",
                response: clinics
            );
            return Ok(response);
        }
    }
}
