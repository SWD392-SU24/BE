using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Clinics
{
    public interface IClinicService
    {
        Task<List<ClinicResponse>> GetAllClinicsAsync();
        Task<ClinicResponse> AddClinicAsync(ClinicRequest clinicRequest);
        Task<ClinicResponse> UpdateClinicAsync(int clinicId, ClinicRequest clinicRequest);
        Task DeleteClinicAsync(int clinicId);
        Task<List<ClinicResponse>> GetClinicsByNameAsync(string? clinicName);
    }
}
