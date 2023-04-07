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

    public async Task<IEnumerable<UserInfoResponse>> GetAllAsync(Guid userId)
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserInfoResponse>>(users);
    }

    public async Task<bool> CreateAsync(CreateUserRequest request)
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

        // Assumes that unless user creation in repo has thrown, adding was successful
        return true;
    }

    public async Task<bool> UpdateByIdAsync(UpdateUserRequest request, Guid userId)
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

        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid userId)
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

        return true;
    }
}