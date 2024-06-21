using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Dentists
{
    public interface IDentistService
    {
        Task<IList<DentistResponse>> GetDentistOfAClinic(int clinicId);

        Task<IList<DentistScheduleResponse>> GetScheduleOfADentist(Guid dentistId, DateOnly? fromDate, DateOnly? toDate);

        Task<bool> CreateWorkingScheduleOfADentist(DentistScheduleRequest request);

        Task<bool> DeleteWorkingSchedule(Guid scheduleId, Guid dentistId);

        Task<bool> UpdateWorkingScheduleTime(Guid scheduleId, UpdateScheduleWorkingTimeRequest request);
    }
}
