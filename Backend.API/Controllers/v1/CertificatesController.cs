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

        /// <summary>
        /// Get certificate of a dentist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="certName"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("dentist/{id}/certificates")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<IList<CertificateResponse>>>> GetCertificateOfADentist(Guid id,
            string? certName,
            DateTime? fromDate, DateTime? toDate)
        {
            var certificates = await _certificateService.GetCertificateOfADentist(id, certName, fromDate, toDate);
            var response = new ResponseModel<IList<CertificateResponse>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "List of certificate(s)",
                Response = certificates
            };
            return Ok(response);
        }

        /// <summary>
        /// Get detailed information of a certificate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("certificates/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<CertificateResponse>>> GetCertificate(int id)
        {
            var certificate = await _certificateService.GetDetailedCertificate(id);
            var response = new ResponseModel<CertificateResponse>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate information",
                Response = certificate
            };
            return Ok(response);
        }

        /// <summary>
        /// Create a certificate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("certificate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> AddCertificate([FromBody] CertificateRequest request)
        {
            var result = await _certificateService.AddCertificateOfADentist(request);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Add certificate successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update certificate image and date (issued date, expired date)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("certificate/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> UpdateCertificate(int id, [FromBody] UpdateCertificateRequest request)
        {
            var result = await _certificateService.UpdateCertificateImageAndDate(id, request);
            if (result)
            {
                var response = new ResponseModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Update certificate successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }
        
        /// <summary>
        /// Delete a certificate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dentistId"></param>
        /// <returns></returns>
        [HttpDelete("dentist/{dentistId}/certificate/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<ResponseModel<string>>> DeleteCertificate(int id, Guid dentistId)
        {
            var result = await _certificateService.DeleteCertificate(id, dentistId);
            if (result)
            {
                var response = new ResponseModel<string> 
                { 
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Delete certificate successfully!",
                    Response = null
                };
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
