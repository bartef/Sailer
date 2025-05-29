using Core.DomainModels;
using Core.Entities;
using Core.ReadModels;

namespace Infrastructure.Repositories;

public class DummyUserRepository : IUserReadModelRepository, IUserDomainModelRepository
{
    private static readonly ISet<User> Users = 
        new HashSet<User>
        {
            new User("test@domain.org", "testname", "salt").WithAge(18).WithPhone(48,123123123).WithName("Zykfryt","Częstoklocki"),
            new User("test1@domain.org", "test1name", "salt").WithAge(19).WithPhone(48,123123124).WithName("Mariusz", "Stolecki"),
            new User("test2@domain.org", "test2name", "salt").WithAge(20).WithPhone(48, 123123125).WithName("Jerzy", "Cipek"),
            new User("test3@domain.org", "test3name", "salt"),
        };


    public async Task<User?> Find(string email) => await Task.FromResult(Users.FirstOrDefault(u => u.Email.Value == email));
    public async Task<IEnumerable<User>> GetAll() => await Task.FromResult(Users);

    public async Task Register(User user)
    {
        Users.Add(user);
        await Task.CompletedTask;
    }
    
}