
using DBContext;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // DbContext and Services DI
        builder.Services.AddDbContext<HakDbContext>(options =>
            options.UseSqlServer(DBContext.Constant.ConnetionString));
        builder.Services.AddScoped<IMentorService, MentorService>();
        builder.Services.AddScoped<IScienceService, ScienceService>();
        builder.Services.AddScoped<IProcedureService, ProcedureService>();
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = null;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
