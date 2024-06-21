using AutoMapper;
using Backend.BO.Payloads.Responses;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Backend.BLL.Features.Dentists
{
    public class DentistService : IDentistService
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IMapper _mapper;

        public DentistService(IDentistRepository dentistRepository, IMapper mapper)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
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
    }
}
