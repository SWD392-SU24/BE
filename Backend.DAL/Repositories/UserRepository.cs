using Backend.BO.Commons;
using Backend.DAL.Databases;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Buffers;

namespace Backend.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DenticareContext dbContext) : base(dbContext)
        {
        }

        //public async Task<User?> Authenticate(AuthRequest request)
        //{
        //    return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim() 
        //        && user.Password.ToLower().Trim() == request.Password.ToLower().Trim());

        /*        public async Task<IEnumerable<User>> GetAllUserByRole(string role)
                {
                    return await _dbContext.Users
                        .Where(user => user.Role.ToLower().Trim() == role.ToLower().Trim())
                        .ToListAsync();
                }*/

        public IQueryable<User> GetAllUser(string? name, string? email, string? phoneNumber, string? address, int? sex, string? role)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(user =>
                    user.FirstName.ToLower().Contains(nameLower) ||
                    user.LastName.ToLower().Contains(nameLower));
            }

            if (!string.IsNullOrEmpty(email))
            {
                var emailLower = email.ToLower();
                query = query.Where(user => user.Email.ToLower().Contains(emailLower));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var phoneNumberLower = phoneNumber.ToLower();
                query = query.Where(user => user.PhoneNumber.ToLower().Contains(phoneNumberLower));
            }

            if (!string.IsNullOrEmpty(address))
            {
                var addressLower = address.ToLower();
                query = query.Where(user => user.Address.ToLower().Contains(addressLower));
            }

            if (sex.HasValue)
            {
                query = query.Where(user => user.Sex == sex.Value);
            }

            if (!string.IsNullOrEmpty(role))
            {
                var roleLower = role.ToLower();
                query = query.Where(user => user.Role.ToLower().Contains(roleLower));
            }

            return query;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            _dbContext.Set<User>().Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExistsAsync(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _dbContext.Set<User>().FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> UserExistsAsync(Guid id)
        {
            return await _dbContext.Set<User>().AnyAsync(e => e.Id == id);
        }

    }
}
