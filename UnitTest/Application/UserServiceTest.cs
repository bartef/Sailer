using Application.DTOs;
using Application.Services;
using AutoMapper;
using Core.DomainModels;
using Core.Entities;
using Core.ReadModels;
using Infrastructure.Mappers;
using Moq;
using NUnit.Framework.Internal.Execution;

namespace Test.Application;

[TestFixture]
public class UserServiceTest
{
    private Mock<IUserReadModelRepository> _readModelMock;
    private Mock<IUserDomainModelRepository> _domainModelMock;
    private IMapper _mapper;
    private UserService _sut;

    [SetUp]
    public void SetUp()
    {
        _readModelMock = new Mock<IUserReadModelRepository>();
        _domainModelMock = new Mock<IUserDomainModelRepository>();
        _mapper = AutoMapperConfig.Initialize(); 
        _sut = new UserService(_readModelMock.Object, _domainModelMock.Object, _mapper);
    }

    [Test]
    public void should_get_user_by_email()
    {
        var email = "email@domain.org";
        var expected = new UserDTO(
            email,
            "+11 123 123 123",
            "Jack",
            "Sparrow",
            42
        );
        var expectedUser = new User(
            email, "password123", "salt123"
        ).WithAge(42).WithName("Jack","Sparrow");

        _readModelMock.Setup(cfg => cfg.Find(email))
            .ReturnsAsync(expectedUser);
        var actual = _sut.GetByEmail(email).Result;
        
        Assert.That(expected.Email, Is.EqualTo(actual.Email));
        Assert.That(expected.Age, Is.EqualTo(actual.Age));
        Assert.That(expected.Phone, Is.EqualTo(actual.Phone));
        Assert.That(expected.Name, Is.EqualTo(actual.Name));
        Assert.That(expected.Surname, Is.EqualTo(actual.Surname));
    }

    [Test]
    public void should_throw_exception_when_not_found_user_by_email()
    {
        
    }

    [Test]
    public void should_get_users_collection()
    {
        
    }

    [Test]
    public void should_register_user()
    {
        
    }

    [Test]
    public void should_throw_exception_when_register_user_because_email_already_exist()
    {
        
    }
    
    
}