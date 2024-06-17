using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Certificates
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICertificateService
    {
        /// <summary>
        /// Get certificate of a dentist
        /// </summary>
        /// <param name="dentistId"></param>
        /// <returns></returns>
        Task<IList<CertificateResponse>> GetCertificateOfADentist(Guid dentistId, string? certName, DateTime? fromDate, 
            DateTime? toDate);

        /// <summary>
        /// Get information of a certificate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CertificateResponse> GetDetailedCertificate(int id);

        /// <summary>
        /// Add certificate of a dentist
        /// </summary>
        /// <param name="dentistId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> AddCertificateOfADentist(BO.Payloads.Requests.CertificateRequest request);

        /// <summary>
        /// Delete a certificate of a dentist
        /// </summary>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        Task<bool> DeleteCertificate(int certificateId, Guid dentistId);

        Task<bool> UpdateCertificateImageAndDate(int certId, UpdateCertificateRequest request);
    }
}
