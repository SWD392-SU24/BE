using AutoMapper;
using Backend.BO.Entities;
using Backend.BO.Enums;
using Backend.BO.Payloads.Requests;
using Backend.DAL;
using Backend.DAL.Repositories.Contracts;

namespace Backend.BLL.Features.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper,
            IAppointmentRepository appointmentRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<bool> CreateAppointment(AppointmentRequest request)
        {
            var result = false;
            try
            {
                if (request.AppointmentStartTime > request.AppointmentEndTime)
                    throw new ArgumentException("Start time must be larger than end time!");

                if (request.AppointmentType == (int)AppointmentTypeEnum.Treatment)
                {
                    request.AppointmentEndTime = request.AppointmentStartTime.AddMinutes(15);
                    // check duplicate of time in a treatment appointment
                    var existedAppointment = await _appointmentRepository
                        .GetAsync(a => a.AppointmentDate == request.AppointmentDate && a.AppointmentStartTime == request.AppointmentStartTime
                            && a.AppointmentEndTime == request.AppointmentEndTime);
                    if (existedAppointment is not null)
                        throw new ArgumentException("Error message here!");
                }
                else if (request.AppointmentType == (int)AppointmentTypeEnum.Registration)
                {
                    request.AppointmentEndTime = request.AppointmentEndTime.AddHours(2);
                    // check duplicate of time in a treatment appointment
                    var existedAppointment = await _appointmentRepository
                        .GetAsync(a => a.AppointmentDate == request.AppointmentDate && a.AppointmentStartTime == request.AppointmentStartTime
                            && a.AppointmentEndTime == request.AppointmentEndTime);
                    if (existedAppointment is not null)
                        throw new ArgumentException("Error message here!");
                }
                // TODO: Mapping with appointment id & appointment status: Booking
                var appointment = _mapper.Map<Appointment>(request);
                await _unitOfWork.CommitAsync();
                result = true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            return result;
        }
    }
}
