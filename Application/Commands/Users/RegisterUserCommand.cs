namespace Application.Commands.Users;

public record RegisterUserCommand(string Email, string Password) : ICommand;