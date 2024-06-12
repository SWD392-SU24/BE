using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Clinics
{
    /// <summary>
    /// Interface for clinic services
    /// </summary>
    public interface IClinicService
    {
        Task<ClinicResponse> AddClinicAsync(ClinicRequest clinicRequest);
        Task<ClinicResponse> UpdateClinicAsync(int clinicId, ClinicRequest clinicRequest);
        Task DeleteClinicAsync(int clinicId);
        Task<List<ClinicResponse>> GetClinicsByNameAsync(string? clinicName, int? areaId);
        Task<List<ClinicResponse>> GetAllClinicsByOwnerIdAsync(string ownerId, int? areaId = null, short? clinicState = null);

        /// <summary>
        /// Get feedback of a clinic
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns>List of feedback</returns>
        Task<IList<ClinicFeedbackResponse>> GetFeedbackOfAClinic(int clinicId, DateTime? fromDate, DateTime? toDate);
    }
}
