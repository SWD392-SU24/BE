using Backend.BLL.Features.Certificates;
using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Backend.API.Controllers.v1
{
    public class CertificatesController : BaseApiController
    {
        private readonly ICertificateService _certificateService;

        public CertificatesController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet("dentist-id/{id}/certificates")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<CertificateResponse>>>> GetCertificateOfADentist(Guid id, 
            string? certName, 
            DateTime? fromDate, DateTime? toDate)
        {
            var certificates = await _certificateService.GetCertificateOfADentist(id, certName, fromDate, toDate);
            var response = new ResponseModel<IList<CertificateResponse>>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Certificate(s)",
                response: certificates                
            );
            return Ok(response);
        }
        
        [HttpGet("certificates/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<CertificateResponse>>> GetCertificate(int id)
        {
            var certificate = await _certificateService.GetDetailedCertificate(id);
            var response = new ResponseModel<CertificateResponse>(
                statusCode: (int)HttpStatusCode.OK,
                message: "Detailed Certificate",
                response: certificate
            );
            return Ok(response);
        }

        [HttpPost("certificate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> AddCertificate([FromBody] CertificateRequest request)
        {
            var result = await _certificateService.AddCertificateOfADentist(request);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Add certificate successfully!",
                    response: null
                );
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPatch("certificate/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> UpdateCertificate(int id, [FromBody] CertificateRequest request)
        {
            var result = await _certificateService.UpdateCertificateImageAndDate(id, request);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Update certificate successfully!",
                    response: null
                );
                return Ok(response);
            }
            return BadRequest();
        }
        
        [HttpDelete("dentist-id/{dentistId}/certificate/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> DeleteCertificate(int id, Guid dentistId)
        {
            var result = await _certificateService.DeleteCertificate(id, dentistId);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Delete certificate successfully!",
                    response: null
                );
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
