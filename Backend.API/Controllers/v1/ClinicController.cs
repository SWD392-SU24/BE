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

        /// <summary>
        /// Create a clinic
        /// </summary>
        /// <param name="clinicRequest"></param>
        /// <returns></returns>
        [HttpPost("clinic")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<ClinicResponse>>> AddClinic([FromBody] ClinicRequest clinicRequest)
        {
            var addedClinic = await _clinicService.AddClinicAsync(clinicRequest);
            return Ok(addedClinic);
        }

        /// <summary>
        /// Update a clinic
        /// </summary>
        /// <param name="clinicId"></param>
        /// <param name="clinicRequest"></param>
        /// <returns></returns>
        [HttpPut("clinic/{clinicId}")]
        [ProducesResponseType(typeof(ClinicResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<ClinicResponse>>> UpdateClinic(int clinicId, [FromBody] ClinicRequest clinicRequest)
        {
            var updatedClinic = await _clinicService.UpdateClinicAsync(clinicId, clinicRequest);
            return Ok(updatedClinic);
        }
        
        /// <summary>
        /// Delete a clinic
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns></returns>
        [HttpDelete("clinic/{clinicId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> DeleteClinic(int clinicId)
        {
            await _clinicService.DeleteClinicAsync(clinicId);
            return Ok("Delete Success!");
        }

        /// <summary>
        /// Get detailed information of a clinic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("clinics/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<ClinicCustomerPageResponse>>> GetClinic(int id)
        {
            var clinic = await _clinicService.GetClinic(id);
            var response = new ResponseModel<ClinicCustomerPageResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Information of clinic",
                Response = clinic
            };
            return Ok(response);
        }
        
        /// <summary>
        /// Get clinic by area
        /// </summary>
        /// <param name="clinicName"></param>
        /// <param name="areaId"></param>
        /// <param name="ratings"></param>
        /// <returns></returns>
        [HttpGet("area/{areaId}/clinics")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<List<ClinicResponse>>>> GetClinicByArea(string? clinicName, int areaId, 
            [FromQuery] string[]? ratings)
        {
            var clinics = await _clinicService.GetClinics(areaId, clinicName, ratings);
            var response = new ResponseModel<List<ClinicResponse>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of clinic(s)",
                Response = clinics
            };
            return Ok(response);
        }

        /// <summary>
        /// Get clinic by owner's id
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="areaId"></param>
        /// <param name="clinicState"></param>
        /// <returns></returns>
        [HttpGet("owner/{ownerId}/clinics")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<List<ClinicResponse>>>> GetClinicByOwnerId(string ownerId, int? areaId = null, short? clinicState = null)
        {
            var clinics = await _clinicService.GetAllClinicsByOwnerIdAsync(ownerId, areaId, clinicState);
            var response = new ResponseModel<List<ClinicResponse>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of clinic(s).",
                Response = clinics
            };
            return Ok(response);
        }

        /// <summary>
        /// Get feedback information of a clinic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("clinic/{id}/feedback")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<ClinicFeedbackResponse>>>> GetFeedbackOfAClinic(int id, DateTime? fromDate, DateTime? toDate)
        {            
            var clinics = await _clinicService.GetFeedbackOfAClinic(id, fromDate, toDate);
            var response = new ResponseModel<IList<ClinicFeedbackResponse>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of feedback",
                Response = clinics
            };
            return Ok(response);
        }

        /// <summary>
        /// Get service of a clinic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("clinic/{id}/services")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<ServiceResponse>>>> GetServiceOfAClinic(int id, [FromQuery] string? name)
        {
            var clinics = await _clinicService.GetServiceOfAClinic(id, name);
            var response = new ResponseModel<IList<ServiceResponse>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of service(s)",
                Response = clinics
            };
            return Ok(response);
        }
    }
}
