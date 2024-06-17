using Backend.BO.Entities;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class CertificateRepository : Repository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(DenticareContext dbContext) : base(dbContext)
        {
        }

        public string HelloWorld()
        {
            return string.Empty;
        }
    }
}
