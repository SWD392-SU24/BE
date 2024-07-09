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
        private readonly IAppointmentServiceRepository _appointmentServiceRepository;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper,
            IAppointmentRepository appointmentRepository, 
            IAppointmentServiceRepository appointmentServiceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _appointmentServiceRepository = appointmentServiceRepository;
        }

        public async Task<bool> CreateAppointment(AppointmentRequest request)
        {
            var result = false;
            
            var serviceRepository = _unitOfWork.GetRepository<Service>();
            var treatmentDetailRepository = _unitOfWork.GetRepository<TreatmentDetail>();
            try
            {
                if (request.AppointmentDate < DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Appointment date must not be in the past!");
                
                if (request.AppointmentType == (int)AppointmentTypeEnum.Treatment)
                {
                    request.AppointmentEndTime = request.AppointmentStartTime.AddHours(2);
                    // check duplicate of time in a treatment appointment
                    var existedAppointment = await _appointmentRepository
                        .GetAsync(a => a.AppointmentDate == request.AppointmentDate && a.AppointmentStartTime == request.AppointmentStartTime
                            && a.AppointmentEndTime == request.AppointmentEndTime);
                    if (existedAppointment is not null)
                        throw new ArgumentException("There is already an appointment for this time.");
                }
                else if (request.AppointmentType == (int)AppointmentTypeEnum.Registration)
                {
                    request.AppointmentEndTime = request.AppointmentStartTime.AddMinutes(15);
                    // check duplicate of time in a treatment appointment
                    var existedAppointment = await _appointmentRepository
                        .GetAsync(a => a.AppointmentDate == request.AppointmentDate && a.AppointmentStartTime == request.AppointmentStartTime
                            && a.AppointmentEndTime == request.AppointmentEndTime);
                    if (existedAppointment is not null)
                        throw new ArgumentException("There is already an appointment for this time.");
                }

                var appointment = _mapper.Map<Appointment>(request);
                appointment.AppointmentId = Guid.NewGuid();
                _appointmentRepository.Add(appointment);

                // Handle key conflict between Appointment and TreatmentDetail table
                var treatmentDetail = new TreatmentDetail
                {
                    AppointmentId = appointment.AppointmentId,
                };
                treatmentDetailRepository.Add(treatmentDetail);

                foreach (var service in request.Services)
                {
                    var existedService = await serviceRepository.GetByIdAsync(service.ServiceId) ?? throw new ArgumentException($"Service with ID {service.ServiceId} does not exist.");
                    service.AppointmentId = appointment.AppointmentId;
                    var mappedAppointmentService = _mapper.Map<BO.Entities.AppointmentService>(service);
                    _appointmentServiceRepository.Add(mappedAppointmentService);
                }

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
