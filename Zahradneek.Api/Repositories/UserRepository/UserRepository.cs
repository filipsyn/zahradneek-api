using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public UserRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
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

    public async Task<bool> UpdateAsync(User updatedUser, int userId)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId );
        if (user is null)
            throw new NotFoundException("User was not found");

        _mapper.Map(updatedUser, user);
        _db.Users.Update(user);
        var changedRowCount = await _db.SaveChangesAsync();
        return changedRowCount > 0;
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