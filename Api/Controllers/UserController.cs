using Application.Commands.Users;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : Controller
{
    
    [HttpGet]
    [Route("{email}")]
    public async Task<IActionResult> GetByEmail(string email) 
    {
        try
        {
            var user = await userService.GetByEmail(email);
            return Json(user);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    

    [HttpGet] 
    public async Task<IEnumerable<UserDTO>> GetAll() => await userService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        await userService.Register(command);
        return Created($"user/{command.Email}", new object());
    }
}