using CopilotApi.Interfaces;
using CopilotApi.Models;
using CopilotApi.Services;
using CopilotApi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PatientSettings>(
    builder.Configuration.GetSection(nameof(PatientSettings)));

builder.Services.Configure<DoctorSettings>(
    builder.Configuration.GetSection(nameof(DoctorSettings)));

builder.Services.AddSingleton<IPatientSettings>(sp =>
    sp.GetRequiredService<IOptions<PatientSettings>>().Value);

builder.Services.AddSingleton<IDoctorSettings>(sp =>
    (IDoctorSettings)sp.GetRequiredService<IOptions<DoctorSettings>>().Value);

builder.Services.Configure<IAppointmentSettings>(builder.Configuration.GetSection(nameof(IAppointmentSettings)));

builder.Services.AddSingleton<IAppointmentSettings, AppointmentSettings>();

builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
{
    var settings = ServiceProvider.GetRequiredService<IOptions<PatientSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IAppointmentServices, AppointmentService>(); // Added this line

builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CopilotApi", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});



// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopilotApi v1"));
}

app.UseHttpsRedirection();

app.UseCors("AllowMyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
