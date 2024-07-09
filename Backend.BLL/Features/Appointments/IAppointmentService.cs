using Backend.BO.Payloads.Requests;

namespace Backend.BLL.Features.Appointments
{
    public interface IAppointmentService
    {
        //Task<IList<>> GetAppointmentOfACustomer(Guid customerId)

        Task<bool> CreateAppointment(AppointmentRequest request);
    }
}
