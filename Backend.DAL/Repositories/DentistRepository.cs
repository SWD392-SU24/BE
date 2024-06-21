using Backend.BO.Entities;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class DentistRepository : Repository<Dentist>, IDentistRepository
    {
        public DentistRepository(DenticareContext dbContext) : base(dbContext)
        {
        }


    }
}
