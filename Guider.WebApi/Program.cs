using Guider.Application.Core.Mapping;
using Guider.Application.Interfaces;
using Guider.Application.Services;
using Guider.Domain.Core.Repositories;
using Guider.Infrastructure.Data;
using Guider.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TravelGuiderDb")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IBaseRepositoryProvider, BaseRepositoryProvider>();
builder.Services.AddScoped<IInstitutionService, InstitutionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagService, TagService>();

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
