
using DBoperationWithEFWEbApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Web.Http.Cors;

namespace DBoperationWithEFWEbApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
			var builder = WebApplication.CreateBuilder(args);

			

			builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));
			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
									  // builder.WithOrigins("http://192.168.0.201").AllowAnyMethod().AllowAnyHeader();
									  // builder.WithOrigins("http://15.207.68.142:777").AllowAnyMethod().AllowAnyHeader();
									  //builder.WithOrigins("https://rebatedemo.qualitechgroup.in").AllowAnyMethod().AllowAnyHeader();
								  });
			});
			var app = builder.Build();
			app.UseCors();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors(MyAllowSpecificOrigins);
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}