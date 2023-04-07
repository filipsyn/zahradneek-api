using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.UserRepository;

namespace Zahradneek.Api.Services.UserService;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserInfoResponse> GetByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException("User was not found");

        return _mapper.Map<UserInfoResponse>(user);
    }

    public async Task<IEnumerable<UserInfoResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserInfoResponse>>(users);
    }

    public async Task CreateAsync(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        try
        {
            await _userRepository.CreateAsync(user);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task UpdateByIdAsync(UpdateUserRequest request, Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException("User was not found");

        var updatedUser = _mapper.Map<User>(request);

        try
        {
            await _userRepository.UpdateAsync(updatedUser);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task DeleteByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException("User was not found");

        try
        {
            await _userRepository.DeleteByIdAsync(userId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }
}