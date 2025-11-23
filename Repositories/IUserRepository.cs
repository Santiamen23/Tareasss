using BooksTW.Models;

namespace BooksTW.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAddress(string email);
        Task<User?> GetByRefreshToken(string refreshToken);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
