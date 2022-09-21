using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Proyecto.Data;
using System.Text;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



////Learn more about configuring Swagger()
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clase2WebApi", Version = "v1" });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement {{ new OpenApiSecurityScheme { Reference = new OpenApiReference{
//                    Type = ReferenceType.SecurityScheme,
//                     Id = "Bearer"}
//                    },
//                     new string[] { }
//                  } });
//});




//automapper

builder.Services.AddAutoMapper(typeof(Program));


//inyeccion de base de datos 
builder.Services
    .AddDbContext<HoteleriaContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("Default")));


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
