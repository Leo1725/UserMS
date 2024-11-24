using UserMs.Infrastructure.Database;
using UserMs.Infrastructure.Repositories;
using UserMs.Infrastructure.Settings;
using UserMS.Core.DataBase;
using UserMS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using UserMS.Application.Handlers.Commands;
using UserMS.Application.Handlers.Querys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Algo parecido a las variables goblales en el typescript 
var _appSettings = new AppSettings();
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
_appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.Configure<AppSettings>(appSettingsSection);

//estoy registrando los servicios de dbContext y repo para el operator
builder.Services.AddMediatR(typeof(GetAllOperatorsQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateOperatorCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateOperatorCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteOperatorCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(GetOperatorQueryHandler).Assembly);
builder.Services.AddTransient<IOperatorDbContext, OperatorDbContext>();
builder.Services.AddTransient<IOperatorRepository, OperatorRepository>();

var dbConnectionString = builder.Configuration.GetValue<string>("DBConnectionString");
builder.Services.AddDbContext<OperatorDbContext>(options =>
options.UseNpgsql(dbConnectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
