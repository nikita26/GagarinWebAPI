using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class UserRepository : Repository<User,long>,IUserRepository
    {
        public UserRepository(DataBaseContext contex)
            : base(contex) { }

        public Task<User?> GetByLoginAsync(string login)
        {
            return dbSet.FirstOrDefaultAsync(e => e.Login == login);
        }
    }
}