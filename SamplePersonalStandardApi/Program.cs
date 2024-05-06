using SamplePersonalStandard.Application;
using SamplePersonalStandard.Infrastructure.Persistence;
using System.Configuration;

namespace SamplePersonalStandardApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO: Change all validation and [Require] annotatios to fluent validation
            //TODO: Implement Facade + Controller to handle new Buyers and retrieve order for buyer [instead use CQRS, for more examples]
            //TODO: Implement HTTP Base + currency converter https://rapidapi.com/natkapral/api/currency-converter5/
            //TODO: Add Authorization with OAuth2
            //TODO: Add Exception Handler + ResultDto

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEntityFrameworkInfrastructure(builder.Configuration.GetConnectionString("SqlServerConnection"));
            builder.Services.AddApplication();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
