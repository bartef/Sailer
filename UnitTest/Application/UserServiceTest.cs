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
    private string _dummyEmail;

    [SetUp]
    public void SetUp()
    {
        _readModelMock = new Mock<IUserReadModelRepository>();
        _domainModelMock = new Mock<IUserDomainModelRepository>();
        _mapper = AutoMapperConfig.Initialize();
        _sut = new UserService(_readModelMock.Object, _domainModelMock.Object, _mapper);
        _dummyEmail = "email@domain.org";
    }

    [Test]
    public void should_get_user_by_email()
    {
        var expected = new UserDTO(
            _dummyEmail,
            "+11 123 123 123",
            "Jack",
            "Sparrow",
            42
        );

        _readModelMock.Setup(
                cfg => cfg.Find(_dummyEmail)
            ).ReturnsAsync(
                new User(_dummyEmail, "password123", "salt123")
                .WithAge(42)
                .WithName("Jack","Sparrow")
                .WithPhone(11, 123123123)
            );
        
        var actual = _sut.GetByEmail(_dummyEmail).Result;
        
        Assert.That(expected.Email, Is.EqualTo(actual.Result.Email));
        Assert.That(expected.Age, Is.EqualTo(actual.Result.Age));
        Assert.That(expected.Phone, Is.EqualTo(actual.Result.Phone));
        Assert.That(expected.Name, Is.EqualTo(actual.Result.Name));
        Assert.That(expected.Surname, Is.EqualTo(actual.Result.Surname));
    }

    [Test]
    public void should_get_task_with_exception_when_not_found_user_by_email()
    {
        _readModelMock.Setup(
            cfg => cfg.Find(_dummyEmail)
        ).ReturnsAsync(value: null!);

        var actual = _sut.GetByEmail(_dummyEmail);
            
        Assert.That(actual.Result.Exception?.Message == $"One or more errors occurred. (User with email {_dummyEmail} not found.)");
    
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