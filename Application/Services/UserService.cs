using Application.Commands.Users;
using Application.DTOs;
using Application.Exceptions;
using AutoMapper;
using Core.DomainModels;
using Core.Entities;
using Core.ReadModels;

namespace Application.Services;

public class UserService(
    IUserReadModelRepository readModelRepository, 
    IUserDomainModelRepository domainModelRepository,
    IMapper mapper)
{
    public async Task Register(RegisterUserCommand command)
    {
        var user = await readModelRepository.Find(command.Email);
        if (user != null) throw new System.Exception($"$User with email {command.Email} already exists!"); // TODO custom exception

        await domainModelRepository.Register(
            new User(
                command.Email,
                command.Password,
                Guid.NewGuid().ToString("N")
            )    
        );
    }

    public async Task<IEnumerable<UserDTO>> GetAll()
    {
        // TODO - use mapper
        HashSet<UserDTO> userDTOs = new HashSet<UserDTO>();
        var users = await readModelRepository.GetAll();
        foreach (User user in users)
        {
            userDTOs.Add(
                new UserDTO(
                    user.Email.Value,
                    user.Phone?.Present(),
                    user.UserName?.Name,
                    user.UserName?.Surname,
                    user.Age?.Value
                )
            );
        }

        return userDTOs;
    }

    public async Task<Task<UserDTO>> GetByEmail(string email)
    {
        var user = await readModelRepository.Find(email);
        if (user == null)
        {
            return Task.FromException<UserDTO>(UserServiceException.UserNotFound(email));
        }
        return Task.FromResult(mapper.Map<User, UserDTO>(user));
    }
}