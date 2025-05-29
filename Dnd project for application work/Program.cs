using Dnd_project_for_application_work.Infrastructure_Layer.Persistence_DbContext;
using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.Application_Layer.Services;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Infrastructure_Layer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository registrations
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IAlignmentRepository, AlignmentRepository>();   
builder.Services.AddScoped<IRaceRepository, RaceRepository>();             
builder.Services.AddScoped<IClassRepository, ClassRepository>();           

// Application Services
builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddScoped<AlignmentService>();
builder.Services.AddScoped<RaceService>();
builder.Services.AddScoped<ClassService>();


// Controller, Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
