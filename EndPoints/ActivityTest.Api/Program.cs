using ActivityTest.Application.ActivityType.Add;
using ActivityTest.Infrastructure.Utilities;
using ActivityTest.Query.ActivityTypeQuery.GetById;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaulConnection");
InfrastructureDI.Init(builder.Services,connectionString);

builder.Services.AddMediatR(typeof(AddActivityTypeCommand).Assembly);
builder.Services.AddMediatR(typeof(GetActivityTypeByIdQuery).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
