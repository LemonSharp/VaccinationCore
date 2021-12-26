using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;
using LemonSharp.VaccinationCore.Infrastructure;
using LemonSharp.VaccinationCore.Infrastructure.Repositories;
using LemonSharp.VaccinationCore.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddSingleton<IAppointmentQueries, AppointmentQueries>();
builder.Services.AddSingleton<IVaccinationQueries, VaccinationQueries>();

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IAppointmentAppService, AppointmentAppService>();
builder.Services.AddScoped<IVaccinationAppService, VaccinationAppService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVaccinationPlanRepository, VaccinationPlanRepository>();

builder.Services.AddDbContext<VaccinationCoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VaccinationCore"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapSubscribeHandler();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
