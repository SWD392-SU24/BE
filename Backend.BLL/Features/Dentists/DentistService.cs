using AutoMapper;
using Backend.BO.Entities;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Backend.BLL.Features.Dentists
{
    public class DentistService : IDentistService
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DentistService(IDentistRepository dentistRepository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateWorkingScheduleOfADentist(DentistScheduleRequest request)
        {
            var result = false;
            try
            {
                var dentistScheduleRepository = _unitOfWork.GetRepository<DentistSchedule>();
                // Date and time validation
                if (request.WorkingDate <= DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("The working date must be in the future. Please select a date later than today!");
                if (request.WorkingStartTime > request.WorkingEndTime)
                    throw new ArgumentException("Start time must be smaller than end time!");
                // Check duplicate of time in a working day
                var availableSchedules = await dentistScheduleRepository.GetAll()
                    .Where(s => s.WorkingDate == request.WorkingDate)
                    .AsNoTracking()
                    .ToListAsync();
                foreach (var item in availableSchedules)
                {
                    if (item.WorkingStartTime == request.WorkingStartTime && item.WorkingEndTime == request.WorkingEndTime)
                        throw new ArgumentException("This schedule has already existed!");
                }
                var schedule = _mapper.Map<DentistSchedule>(request);

                dentistScheduleRepository.Add(schedule);
                await _unitOfWork.CommitAsync();
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> DeleteWorkingSchedule(Guid scheduleId, Guid dentistId)
        {
            var result = false;
            try
            {
                var dentistScheduleRepository = _unitOfWork.GetRepository<DentistSchedule>();
                var schedule = await dentistScheduleRepository.GetAsync(s => s.ScheduleId == scheduleId && s.DentistId == dentistId);
                if (schedule is null)
                    throw new KeyNotFoundException("Schedule does not exist!");

                dentistScheduleRepository.Delete(schedule);
                await _unitOfWork.CommitAsync();
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<IList<DentistResponse>> GetDentistOfAClinic(int clinicId)
        {
            try
            {
                var dentists = await _dentistRepository.GetAll()
                    .Include(d => d.ClinicDentists)
                    .Where(d => d.ClinicDentists.Any(x => x.ClinicId == clinicId))
                    .AsNoTracking()
                    .ToListAsync();

                if (!dentists.Any())
                    throw new InvalidOperationException("No data of dentist for this clinic!");
                var response = _mapper.Map<IList<DentistResponse>>(dentists);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<DentistScheduleResponse>> GetScheduleOfADentist(Guid dentistId, DateOnly? fromDate, DateOnly? toDate)
        {
            try
            {
                var dentistScheduleRepository = _unitOfWork.GetRepository<DentistSchedule>();
                var workingSchedules = await dentistScheduleRepository.GetAll()
                    .Where(s => s.DentistId == dentistId)
                    .AsNoTracking()
                    .ToListAsync();
                if (!workingSchedules.Any())
                    throw new InvalidOperationException("No date of schedule for this dentist!");

                if (fromDate.HasValue && toDate.HasValue)
                {
                    workingSchedules = workingSchedules
                        .Where(s => s.WorkingDate >= fromDate.Value && s.WorkingDate <= toDate.Value)
                        .ToList();
                }
                var response = _mapper.Map<IList<DentistScheduleResponse>>(workingSchedules);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateWorkingScheduleTime(Guid scheduleId, UpdateScheduleWorkingTimeRequest request)
        {
            var result = false;
            try
            {
                if (request.WorkingStartTime > request.WorkingEndTime)
                    throw new ArgumentException("Start time must be smaller than end time!");
                
                var dentistScheduleRepository = _unitOfWork.GetRepository<DentistSchedule>();
                var schedule = await dentistScheduleRepository
                    .GetAsync(s => s.ScheduleId == scheduleId && s.DentistId == request.DentistId);
                if (schedule is null)
                    throw new KeyNotFoundException("Schedule does not exist!");

                var updatedSchedule = _mapper.Map(request, schedule);
                // Check duplicate of time in a working day
                var availableSchedules = await dentistScheduleRepository.GetAll()
                    .Where(s => s.WorkingDate == updatedSchedule.WorkingDate)
                    .AsNoTracking()
                    .ToListAsync();
                foreach (var item in availableSchedules)
                {
                    if (item.WorkingStartTime == updatedSchedule.WorkingStartTime && item.WorkingEndTime == updatedSchedule.WorkingEndTime)
                        throw new ArgumentException("This schedule has already existed!");
                }
                dentistScheduleRepository.Update(updatedSchedule);
                await _unitOfWork.CommitAsync();
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
