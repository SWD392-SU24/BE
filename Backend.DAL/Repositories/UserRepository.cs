using Backend.BO.Commons;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<User?> Authenticate(AuthRequest request)
        //{
        //    return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim() 
        //        && user.Password.ToLower().Trim() == request.Password.ToLower().Trim());
    }
}
