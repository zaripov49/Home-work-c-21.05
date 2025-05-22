using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<StudentService, StudentService>();
builder.Services.AddScoped<CourseService, CourseService>();
builder.Services.AddScoped<MentorService, MentorService>();
builder.Services.AddScoped<GroupService, GroupService>();
builder.Services.AddScoped<StudentGroupService, StudentGroupService>();
builder.Services.AddScoped<StatisticsService, StatisticsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "My App"));
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
