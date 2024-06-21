using Backend.BLL.Features.Dentists;
using Backend.BO.Commons;
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

        // GET api/<DentistsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DentistsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<DentistsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DentistsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
