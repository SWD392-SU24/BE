using Backend.BO.Entities;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class ClinicRepository : Repository<Clinic>, IClinicRepository
    {
        public ClinicRepository(DenticareContext dbContext) : base(dbContext)
        {
        }
    }
}
