using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TesteTecnico.Dados.Banco;

namespace TesteTecnico.API.Infraestrutura
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AdicionarContext(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddUserSecrets<Program>();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TesteTecnicoContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped(typeof(DAL<>));

            return builder;
        }

        public static WebApplicationBuilder AdicionarSerializadorConfig(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            return builder;
        }

        public static WebApplicationBuilder AdicionarSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplicationBuilder AdicionarAngularCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy
                      .WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                });
            });

            return builder;
        }
    }
}