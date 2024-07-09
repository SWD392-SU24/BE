using Backend.BO.Entities;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DenticareContext dbContext) : base(dbContext)
        {
        }


    }
}
