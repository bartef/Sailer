using Application.Services;
using Core.DomainModels;
using Core.ReadModels;
using Infrastructure.Mappers;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserReadModelRepository, DummyUserRepository>();
builder.Services.AddScoped<IUserDomainModelRepository, DummyUserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
