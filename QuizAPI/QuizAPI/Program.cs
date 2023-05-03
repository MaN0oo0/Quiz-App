using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configer DBContext
            builder.Services.AddDbContext<ApplicationContext>
                (
                opt =>
                {
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });















            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(opt=>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            }
            );


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}