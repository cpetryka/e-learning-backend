using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;


    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AboutMeDTO?> GetAboutMeAsync(Guid userId)
    {
        var user = await _usersRepository.GetByIdAsync(userId);
        if (user == null) return null;

        return new AboutMeDTO
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            PhoneNumber = user.Phone,
            Description = user.AboutMe,
        };
    }

    public Task<bool> ExistsAsync(Guid userId)
        => _usersRepository.ExistsAsync(userId);

    public Task<Guid?> GetIdByEmailAsync(string email)
        => _usersRepository.GetIdByEmailAsync(email);
}