using Backend.BLL.Features.Dentists;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class DentistsController : BaseApiController
    {
        private readonly IDentistService _dentistService;

        public DentistsController(IDentistService dentistService)
        {
            _dentistService = dentistService;
        }

        /// <summary>
        /// Get dentist of a clinic
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns></returns>
        [HttpGet("clinic/{clinicId}/dentists")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<DentistResponse>>>> GetDentistOfAClinic(int clinicId)
        {
            var dentists = await _dentistService.GetDentistOfAClinic(clinicId);
            var response = new ResponseModel<IList<DentistResponse>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of dentist(s)",
                Response = dentists
            };
            return Ok(response);
        }

        /// <summary>
        /// Get working schedule of a dentist
        /// </summary>
        /// <param name="dentistId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("dentist/{dentistId}/working-schedules")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<DentistScheduleResponse>>>> GetScheduleOfADentist(Guid dentistId,
            DateOnly? fromDate, DateOnly? toDate)
        {
            var schedules = await _dentistService.GetScheduleOfADentist(dentistId, fromDate, toDate);
            var response = new ResponseModel<IList<DentistScheduleResponse>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of schedule(s)",
                Response = schedules
            };
            return Ok(response);

        }

        /// <summary>
        /// Create working schedule
        /// </summary>
        /// <param name="dentistId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("dentist/{dentistId}/working-schedule")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> AddWorkingScheduleOfADentist(Guid dentistId, [FromBody] DentistScheduleRequest request)
        {
            if (dentistId != request.DentistId)
            {
                return BadRequest("Dentist's id does not match!");
            }

            if (!ModelState.IsValid) return BadRequest();
            var result = await _dentistService.CreateWorkingScheduleOfADentist(request);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Create schedule successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update working schedule time
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("working-schedule/{scheduleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> UpdateWorkingScheduleTime(Guid scheduleId, [FromBody] UpdateScheduleWorkingTimeRequest request)
        {
            var result = await _dentistService.UpdateWorkingScheduleTime(scheduleId, request);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Update schedule successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a working schedule
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <param name="dentistId"></param>
        /// <returns></returns>
        [HttpDelete("dentist/{dentistId}/working-schedule/{scheduleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> DeleteWorkingSchedule(Guid scheduleId, Guid dentistId)
        {
            var result = await _dentistService.DeleteWorkingSchedule(scheduleId, dentistId);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Remove schedule successfully!",
                    Response = null
                };
                return response;
            }
            return BadRequest();
        }
    }
}
