using Microsoft.EntityFrameworkCore;
using BooksTW.Data;
using BooksTW.Models;

namespace BooksTW.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { _context = context; }

        public Task<User?> GetByEmailAddress(string email) =>
            _context.users.FirstOrDefaultAsync(u => u.Email == email);

        public Task<User?> GetByRefreshToken(string refreshToken) =>
            _context.users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

        public async Task AddAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
