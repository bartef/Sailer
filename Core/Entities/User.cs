using Core.ValueObjects;

namespace Core.Entities;

public class User(
    string email,
    string password,
    string salt)
{
    public UserId UserId { get; } = new(Guid.NewGuid());
    public Email Email{ get; } = new(email);
    public Password Password{ get; } = new(password, salt);
    public DateTime CreatedAt{ get; } = DateTime.UtcNow;

    public UserName? UserName{ get; private set; } 
    public Phone? Phone{ get; private set;} 
    public Age? Age{ get;private set; } 
    
    public User WithName(string name, string surname)
    {
        UserName = new UserName(name, surname);
        return this;
    }
    
    public User WithPhone(int prefix, int phoneNumber)
    {
        Phone = new Phone(prefix, phoneNumber);
        return this;
    }
    
    public User WithAge(int age)
    {
        Age = new Age(age);
        return this;
    }
}