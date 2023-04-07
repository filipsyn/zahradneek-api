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

    public async Task<User?> GetByIdAsync(int userId) =>
        await _db.Users.FirstOrDefaultAsync(user => user.Id == userId);

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _db.Users.ToListAsync();

    public async Task<IEnumerable<User>> GetWhereAsync(Expression<Func<User, bool>> predicate) =>
        await _db.Users.Where(predicate: predicate).ToListAsync();

    public async Task<bool> CreateAsync(User user)
    {
        _db.Users.Add(user);
        var changedRowsCount = await _db.SaveChangesAsync();
        return (changedRowsCount == 1);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        _db.Entry(user).State = EntityState.Modified;
        var changedRowsCount = await _db.SaveChangesAsync();
        return (changedRowsCount > 0);
    }

    public async Task<bool> DeleteByIdAsync(int userId)
    {
        var foundUser = await this.GetByIdAsync(userId);
        if (foundUser is null)
            return false;

        _db.Users.Remove(foundUser);
        var changedRowsCount = await _db.SaveChangesAsync();
        return (changedRowsCount == 1);
    }
}