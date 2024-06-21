using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Dentists
{
    public interface IDentistService
    {
        Task<IList<DentistResponse>> GetDentistOfAClinic(int clinicId);
    }
}
