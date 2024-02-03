using DataBasePatient.Data.Interfaces.IServices;
using DataBasePatient.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //swagger/index.html
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
