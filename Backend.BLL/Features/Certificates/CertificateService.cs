using AutoMapper;
using Backend.BO.Entities;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Backend.BLL.Features.Certificates
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificateService(ICertificateRepository certificateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddCertificateOfADentist(CertificateRequest request)
        {
            var result = false;
            try
            {
                if (request is null)
                    throw new ArgumentException("Request from client is empty.");
                if (string.IsNullOrEmpty(request.CertificateName))
                    throw new ArgumentException("Certificate name is required.");

                var certificate = _mapper.Map<Certificate>(request);
                _certificateRepository.Add(certificate);
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
        
        public async Task<bool> DeleteCertificate(int certificateId, Guid dentistId)
        {
            var result = false;
            try
            {
                var certificate = await _certificateRepository
                    .GetAsync(x => x.Id == certificateId && x.DentistId == dentistId);
                if (certificate is null)
                    throw new KeyNotFoundException("Certificate does not exist!");

                _certificateRepository.Delete(certificate);
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

        public async Task<IList<CertificateResponse>> GetCertificateOfADentist(Guid dentistId, string? certName, 
            DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var certificates = await _certificateRepository.GetAll()
                    .Where(x => x.DentistId == dentistId)
                    .AsNoTracking()
                    .ToListAsync();

                if (!certificates.Any())
                    throw new InvalidOperationException("No data of certificate.");

                // Search & filter with conditions
                if (!string.IsNullOrEmpty(certName))
                {
                    var response = certificates
                        .Where(x => x.CertificateName.Contains(certName))
                        .ToList();
                    return _mapper.Map<IList<CertificateResponse>>(response);
                }
                else if (fromDate is not null && toDate is not null)
                {
                    var response = certificates
                        .Where(x => x.IssuedDate >= fromDate && x.IssuedDate <= toDate)
                        .ToList();
                    return _mapper.Map<IList<CertificateResponse>>(response);
                }
                else if (!string.IsNullOrEmpty(certName) && fromDate is not null && toDate is not null)
                {
                    var response = certificates
                        .Where(x => x.IssuedDate >= fromDate && x.IssuedDate <= toDate && x.CertificateName.Contains(certName))
                        .ToList();
                    return _mapper.Map<IList<CertificateResponse>>(response);
                }
                return _mapper.Map<IList<CertificateResponse>>(certificates);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CertificateResponse> GetDetailedCertificate(int id)
        {
            try
            {
                var certificate = await _certificateRepository.GetAsync(x => x.Id == id);
                if (certificate is null)
                    throw new KeyNotFoundException("Certificate does not exist!");

                var response = _mapper.Map<CertificateResponse>(certificate);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateCertificateImageAndDate(int certId, UpdateCertificateRequest request)
        {
            var result = false;
            try
            {
                if (request is null)
                    throw new ArgumentException("Request from client is empty.");
                
                var certificate = await _certificateRepository
                    .GetAsync(x => x.Id == certId && x.DentistId == request.DentistId);
                if (certificate is null)
                    throw new KeyNotFoundException("Certificate does not exist.");

                var updatedCert = _mapper.Map(request, certificate);
                _certificateRepository.Update(updatedCert);
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
