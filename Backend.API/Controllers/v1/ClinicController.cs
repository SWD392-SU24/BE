using Backend.BLL.Features.Clinics;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("area/{areaId}/clinics")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<List<ClinicResponse>>>> GetClinics(string? clinicName, int areaId, 
            [FromQuery] string[]? ratings)
        {
            var clinics = await _clinicService.GetClinics(areaId, clinicName, ratings);
            var response = new ResponseModel<List<ClinicResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "List of clinic(s)",
                response: clinics
            );

            return Ok(response);
        }

        [HttpGet("owner/{ownerId}/clinics")]
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
        public async Task<ActionResult<ResponseModel<IList<ClinicFeedbackResponse>>>> GetFeedbackOfAClinic(int id, DateTime? fromDate, DateTime? toDate)
        {            
            var clinics = await _clinicService.GetFeedbackOfAClinic(id, fromDate, toDate);

            var response = new ResponseModel<IList<ClinicFeedbackResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Data retrival success!",
                response: clinics
            );
            return Ok(response);
        }

        [HttpGet("clinic/{id}/services")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<ServiceResponse>>>> GetServiceOfAClinic(int id)
        {
            var clinics = await _clinicService.GetServiceOfAClinic(id);

            var response = new ResponseModel<IList<ServiceResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Data of service",
                response: clinics
            );
            return Ok(response);
        }
    }
}
