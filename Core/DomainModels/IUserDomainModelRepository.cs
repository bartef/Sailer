using Core.Entities;

namespace Core.DomainModels;

public interface IUserDomainModelRepository
{
    public Task Register(User user);
}