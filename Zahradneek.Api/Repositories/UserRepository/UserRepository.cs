using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _db;

    public UserRepository(DataContext db)
    {
        _db = db;
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _db.Users.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<IEnumerable<User>> GetWhereAsync(Expression<Func<User, bool>> predicate)
    {
        return await _db.Users.Where(predicate: predicate).ToListAsync();
    }

    public async Task<bool> CreateAsync(User user)
    {
        _db.Users.Add(user);
        var addedRowsCount = await _db.SaveChangesAsync();
        return (addedRowsCount == 1);
    }

    public Task<bool> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}