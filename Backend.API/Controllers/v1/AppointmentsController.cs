using Backend.BLL.Features.Appointments;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class AppointmentsController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<AppointmentsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// Booking an appointment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("booking-appointment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> RegisterAppointment([FromBody] AppointmentRequest request)
        {
            var result = await _appointmentService.CreateAppointment(request);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Register appointment successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }

        // PUT api/<AppointmentsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<AppointmentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
