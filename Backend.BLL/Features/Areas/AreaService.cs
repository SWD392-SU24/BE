using AutoMapper;
using Backend.BO.Entities;
using Backend.BO.Payloads.Responses;
using Backend.DAL;
using Microsoft.EntityFrameworkCore;

namespace Backend.BLL.Features.Areas
{
    public class AreaService : IAreaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AreaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<AreaResponse>> GetAreas()
        {
            try
            {
                var areaRepository = _unitOfWork.GetRepository<Area>();
                var areas = await areaRepository.GetAll()
                    .AsNoTracking()
                    .ToListAsync();
                if (!areas.Any())
                    throw new InvalidOperationException("No data for area!");
                
                var response = _mapper.Map<IList<AreaResponse>>(areas);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
