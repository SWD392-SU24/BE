using Backend.BO.Entities;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class AppointmentServiceRepository : Repository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(DenticareContext dbContext) : base(dbContext)
        {
        }
    }
}
