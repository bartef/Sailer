namespace Application.DTOs;

public record UserDTO(string Email, string? Phone, string? Name, string? Surname, int? Age);