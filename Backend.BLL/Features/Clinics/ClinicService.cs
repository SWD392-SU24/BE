﻿using AutoMapper;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.BO.Payloads.Requests;
using Backend.BO.Commons;

namespace Backend.BLL.Features.Clinics
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClinicResponse> AddClinicAsync(ClinicRequest clinicRequest)
        {
            ValidateClinicRequest(clinicRequest);
            await ValidateOwnerAsync(clinicRequest.OwnerId);
            await ValidateAreaAsync(clinicRequest.AreaId);

            var clinicRepository = _unitOfWork.GetRepository<Clinic>();
            var clinicEntity = _mapper.Map<Clinic>(clinicRequest);

            clinicEntity.ClinicState = 1;

            await clinicRepository.AddAsync(clinicEntity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ClinicResponse>(clinicEntity);
        }

        public async Task<ClinicResponse> UpdateClinicAsync(int clinicId, ClinicRequest clinicRequest)
        {
            var clinicRepository = _unitOfWork.GetRepository<Clinic>();
            var existingClinic = await clinicRepository.GetByIdAsync(clinicId);

            if (existingClinic == null)
            {
                throw new KeyNotFoundException("Clinic not found");
            }

            if (!string.IsNullOrWhiteSpace(clinicRequest.ClinicName))
            {
                existingClinic.ClinicName = clinicRequest.ClinicName;
            }
            if (!string.IsNullOrWhiteSpace(clinicRequest.LicenseNumber))
            {
                existingClinic.LicenseNumber = clinicRequest.LicenseNumber;
            }
            if (!string.IsNullOrWhiteSpace(clinicRequest.Address))
            {
                existingClinic.Address = clinicRequest.Address;
            }
            if (!string.IsNullOrWhiteSpace(clinicRequest.PhoneNumber))
            {
                if (!IsValidPhoneNumber(clinicRequest.PhoneNumber))
                {
                    throw new ArgumentException("Invalid phone number format");
                }
                existingClinic.PhoneNumber = clinicRequest.PhoneNumber;
            }
            //if (!string.IsNullOrWhiteSpace(clinicRequest.EmployeeSize))
            //{
            //    if (int.TryParse(clinicRequest.EmployeeSize, out int numberOfEmployees) && numberOfEmployees > 0)
            //    {
            //        existingClinic.EmployeeSize = EmployeeSize;
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Invalid value for EmployeeSize");
            //    }
            //}
            if (!string.IsNullOrWhiteSpace(clinicRequest.OwnerId))
            {
                if (Guid.TryParse(clinicRequest.OwnerId, out Guid ownerId))
                {
                    existingClinic.OwnerId = ownerId;
                }
                else
                {
                    throw new ArgumentException("Invalid value for OwnerId");
                }
            }
            if (!string.IsNullOrWhiteSpace(clinicRequest.AreaId))
            {
                if (int.TryParse(clinicRequest.AreaId, out int areaId) && areaId > 0)
                {
                    existingClinic.AreaId = areaId;
                }
                else
                {
                    throw new ArgumentException("Invalid value for AreaId");
                }
            }

            clinicRepository.Update(existingClinic);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ClinicResponse>(existingClinic);
        }

        public async Task DeleteClinicAsync(int clinicId)
        {
            var clinicRepository = _unitOfWork.GetRepository<Clinic>();
            var existingClinic = await clinicRepository.GetByIdAsync(clinicId);

            if (existingClinic == null)
            {
                throw new KeyNotFoundException("Clinic not found");
            }

            clinicRepository.Delete(existingClinic);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<ClinicResponse>> GetClinicsByNameAsync(string? clinicName, int? areaId)
        {
            var clinicRepository = _unitOfWork.GetRepository<Clinic>();
            IQueryable<Clinic> query = clinicRepository.GetAll();

            if (!string.IsNullOrEmpty(clinicName))
            {
                query = query.Where(c => c.ClinicName.Contains(clinicName));
            }
            if (areaId.HasValue)
            {
                query = query.Where(c => c.AreaId == areaId.Value);
            }
            var clinics = await query.ToListAsync();
            if (clinics.Count == 0)
            {
                throw new KeyNotFoundException("Clinics not found");
            }
            return _mapper.Map<List<ClinicResponse>>(clinics);
        }
        public async Task<List<ClinicResponse>> GetAllClinicsByOwnerIdAsync(string ownerId, int? areaId = null, short? clinicState = null)
        {
            if (!Guid.TryParse(ownerId, out Guid ownerGuid))
            {
                throw new ArgumentException("Invalid OwnerId");
            }

            var clinicRepository = _unitOfWork.GetRepository<Clinic>();
            IQueryable<Clinic> query = clinicRepository.GetAll().Where(c => c.OwnerId == ownerGuid);

            if (areaId.HasValue)
            {
                query = query.Where(c => c.AreaId == areaId.Value);
            }

            if (clinicState.HasValue)
            {
                query = query.Where(c => c.ClinicState == clinicState.Value);
            }

            var clinics = await query.ToListAsync();

            if (clinics.Count == 0)
            {
                throw new KeyNotFoundException("No clinics found for the specified criteria");
            }

            return _mapper.Map<List<ClinicResponse>>(clinics);
        }

        private void ValidateClinicRequest(ClinicRequest clinicRequest)
        {
            if (string.IsNullOrEmpty(clinicRequest.ClinicName))
            {
                throw new ArgumentException("ClinicName is required");
            }

            if (string.IsNullOrEmpty(clinicRequest.LicenseNumber))
            {
                throw new ArgumentException("LicenseNumber is required");
            }

            if (string.IsNullOrEmpty(clinicRequest.Address))
            {
                throw new ArgumentException("Address is required");
            }

            if (!int.TryParse(clinicRequest.EmployeeSize, out int EmployeeSize) || EmployeeSize <= 0)
            {
                throw new ArgumentException("NumberOfEmployees must be a valid number greater than 0");
            }

            if (!Guid.TryParse(clinicRequest.OwnerId, out _))
            {
                throw new ArgumentException("OwnerId must be a valid GUID");
            }

            if (!int.TryParse(clinicRequest.AreaId, out int areaId) || areaId <= 0)
            {
                throw new ArgumentException("AreaId must be a valid number greater than 0");
            }

            if (!string.IsNullOrEmpty(clinicRequest.PhoneNumber) && !IsValidPhoneNumber(clinicRequest.PhoneNumber))
            {
                throw new ArgumentException("PhoneNumber must be a 10-digit number");
            }
        }

        private async Task ValidateOwnerAsync(string? ownerIdString)
        {
            if (!Guid.TryParse(ownerIdString, out Guid ownerId))
            {
                throw new ArgumentException("OwnerId must be a valid GUID");
            }

            var userRepository = _unitOfWork.GetRepository<User>();
            var user = await userRepository.GetAsync(u => u.Id == ownerId && u.Role == "CO");

            if (user == null)
            {
                throw new InvalidOperationException("OwnerId does not exist or does not have the Owner role.");
            }
        }
        private async Task ValidateAreaAsync(string? areaIdString)
        {
            if (!int.TryParse(areaIdString, out int areaId))
            {
                throw new ArgumentException("AreaId must be a valid number");
            }

            var areaRepository = _unitOfWork.GetRepository<Area>();
            var area = await areaRepository.GetByIdAsync(areaId);

            if (area == null)
            {
                throw new KeyNotFoundException("AreaId does not exist");
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string numericPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return numericPhoneNumber.Length == 10;
        }

        public async Task<IList<ClinicFeedbackResponse>> GetFeedbackOfAClinic(int clinicId, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var clinicRepository = _unitOfWork.GetRepository<Clinic>();
                var response = new List<ClinicFeedbackResponse>();

                if (fromDate.HasValue && toDate.HasValue)
                {
                    var feedback = await clinicRepository.GetAll()
                        .Where(x => x.Id == clinicId)
                        .SelectMany(x => x.ClinicFeedbacks)
                        .Include(x => x.Customer)
                        .Include(x => x.Clinic)
                        .Where(x => x.FeedbackDate >= fromDate && x.FeedbackDate <= toDate)
                        .ToListAsync();

                    if (!feedback.Any())
                        throw new InvalidOperationException("No data for feedback!");

                    foreach (var tmp in feedback)
                    {
                        var mappedFeedback = new ClinicFeedbackResponse();
                        mappedFeedback.ClinicId = tmp.ClinicId;
                        mappedFeedback.ClinicName = tmp.Clinic.ClinicName;
                        mappedFeedback.CustomerId = tmp.CustomerId;
                        mappedFeedback.CustomerName = tmp.Customer.LastName + " " + tmp.Customer.FirstName;
                        mappedFeedback.FeedbackDescription = tmp.FeedbackDescription;
                        mappedFeedback.FeedbackDate = tmp.FeedbackDate;
                        mappedFeedback.Rating = tmp.Rating;

                        response.Add(mappedFeedback);
                    }
                    return response;
                }
                else
                {
                    // No filter
                    var feedback = await clinicRepository.GetAll()
                        .Where(x => x.Id == clinicId)
                        .SelectMany(x => x.ClinicFeedbacks)
                        .Include(x => x.Customer)
                        .Include(x => x.Clinic)
                        .ToListAsync();

                    if (!feedback.Any())
                        throw new InvalidOperationException("No data for feedback!");

                    foreach (var tmp in feedback)
                    {
                        var mappedFeedback = new ClinicFeedbackResponse();
                        mappedFeedback.ClinicId = tmp.ClinicId;
                        mappedFeedback.ClinicName = tmp.Clinic.ClinicName;
                        mappedFeedback.CustomerId = tmp.CustomerId;
                        mappedFeedback.CustomerName = tmp.Customer.LastName + " " + tmp.Customer.FirstName;
                        mappedFeedback.FeedbackDescription = tmp.FeedbackDescription;
                        mappedFeedback.FeedbackDate = tmp.FeedbackDate;
                        mappedFeedback.Rating = tmp.Rating;

                        response.Add(mappedFeedback);
                    }
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<List<ClinicResponse>> GetClinics(int? areaId, string? clinicName, string[]? ratings)
        {
            try
            {
                var clinicRepository = _unitOfWork.GetRepository<Clinic>();
                var query = clinicRepository.GetAll();

                List<short> ratingValues = ratings?.Select(short.Parse).ToList() ?? new List<short>();

                // condition and filter 
                if (areaId.HasValue)
                {
                    query = query.Where(x => x.AreaId == areaId);
                }
                if (!string.IsNullOrEmpty(clinicName))
                {
                    query = query.Where(c => c.ClinicName.Contains(clinicName));
                }
                if (ratings.Any())
                {
                    query = query
                        .Include(x => x.ClinicFeedbacks)
                        .Where(x => x.ClinicFeedbacks.Any(fb => ratingValues.Contains(fb.Rating)));
                }
                var queryResult = await query.ToListAsync();
                if (!queryResult.Any())
                    throw new InvalidOperationException("No data of clinic!");

                return _mapper.Map<List<ClinicResponse>>(queryResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClinicCustomerPageResponse> GetClinic(int clinicId)
        {
            try
            {
                var clinicRepository = _unitOfWork.GetRepository<Clinic>();
                
                var clinic = await clinicRepository.GetAll()
                    .Include(c => c.Services)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == clinicId);
                if (clinic is null)
                    throw new KeyNotFoundException("Clinic does not exist!");

                var clinicResponse = _mapper.Map<ClinicCustomerPageResponse>(clinic);
                clinicResponse.AverageRating = await GetAverageFeedbackRatingOfAClinic(clinicId);

                return clinicResponse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<ServiceResponse>> GetServiceOfAClinic(int clinicId, string? serviceName)
        {
            try
            {
                var clinicRepository = _unitOfWork.GetRepository<Clinic>();
                var services = await clinicRepository.GetAll()
                    .Where(x => x.Id == clinicId)
                    .Include(x => x.Services)
                    .SelectMany(x => x.Services)
                    .ToListAsync();

                if (!services.Any()) 
                    throw new InvalidOperationException("No data of service.");

                if (!string.IsNullOrEmpty(serviceName))
                    services = services
                        .Where(s => s.ServiceName.Contains(serviceName, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                return _mapper.Map<IList<ServiceResponse>>(services);
            }
            catch
            {
                throw;
            }
        }

        public async Task<double> GetAverageFeedbackRatingOfAClinic(int clinicId)
        {
            // initial value
            double result = 0;
            try
            {
                var clinicFeedbackRepository = _unitOfWork.GetRepository<ClinicFeedback>();

                var ratings = await clinicFeedbackRepository.GetAll()
                    .AsNoTracking()
                    .Where(c => c.ClinicId == clinicId)
                    .Select(x => x.Rating)
                    .ToListAsync();

                result = ratings.Select(r => (double)r).Average();
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
