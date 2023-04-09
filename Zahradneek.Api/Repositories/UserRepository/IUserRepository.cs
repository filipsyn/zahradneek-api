using System.Linq.Expressions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.UserRepository;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(int userId);

    public Task<IEnumerable<User>> GetAllAsync();

    public Task<IEnumerable<User>> GetWhereAsync(Expression<Func<User, bool>> predicate);

    public Task<User?> GetByUsernameAsync(string username);

    public Task<bool> CreateAsync(User user);

    public Task<bool> UpdateAsync(User updatedUser, int userId);

    public Task<bool> DeleteByIdAsync(int userId);
}