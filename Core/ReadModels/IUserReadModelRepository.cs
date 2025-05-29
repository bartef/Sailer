using Core.Entities;

namespace Core.ReadModels;

public interface IUserReadModelRepository
{
    public Task<User?> Find(string email); 
    public Task<IEnumerable<User>> GetAll();
}