using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Features.Areas
{
    public interface IAreaService
    {
        Task<IList<AreaResponse>> GetAreas();
    }
}
