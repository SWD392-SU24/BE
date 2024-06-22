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

        [HttpGet("clinic/{clinicId}/dentists")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<DentistResponse>>>> GetDentistOfAClinic(int clinicId)
        {
            var dentists = await _dentistService.GetDentistOfAClinic(clinicId);
            var response = new ResponseModel<IList<DentistResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "List of dentist",
                response: dentists
            );
            return Ok(response);
        }

        [HttpGet("dentist/{dentistId}/working-schedules")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<DentistScheduleResponse>>>> GetScheduleOfADentist(Guid dentistId,
            DateOnly? fromDate, DateOnly? toDate)
        {
            var schedules = await _dentistService.GetScheduleOfADentist(dentistId, fromDate, toDate);
            var response = new ResponseModel<IList<DentistScheduleResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "List of schedule(s)",
                response: schedules
            );
            return Ok(response);

        }

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
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Create schedule successfully!",
                    response: null
                );
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPatch("working-schedule/{scheduleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> UpdateWorkingScheduleTime(Guid scheduleId, [FromBody] UpdateScheduleWorkingTimeRequest request)
        {
            var result = await _dentistService.UpdateWorkingScheduleTime(scheduleId, request);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Update schedule successfully!",
                    response: null
                );
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("dentist/{dentistId}/working-schedule/{scheduleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]

        public async Task<ActionResult<ResponseModel<string>>> DeleteWorkingSchedule(Guid scheduleId, Guid dentistId)
        {
            var result = await _dentistService.DeleteWorkingSchedule(scheduleId, dentistId);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Remove schedule successfully!",
                    response: null
                );
                return response;
            }
            return BadRequest();
        }
    }
}
