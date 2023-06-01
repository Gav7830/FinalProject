using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentalCarWebApi.Utils;
using System.Text;

namespace RentalCarWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string rentalCarCS = builder.Configuration.GetConnectionString("RentalCar");
            int expiresInSeconds = int.Parse(builder.Configuration.GetSection("Jwt:ExpiresInSeconds").Value);
            string key = builder.Configuration.GetSection("Jwt:Key").Value;
            string issuer = builder.Configuration.GetSection("Jwt:Issuer").Value;
            string audience = builder.Configuration.GetSection("Jwt:Audience").Value;

            // Add services to the container.
            builder.Services.AddDbContext<RentalCarDbContext>(cfg => cfg.UseSqlServer(rentalCarCS));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //add cors service
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(cfg =>
            {
                cfg.AddDefaultPolicy(pol =>
                {
                    pol.AllowAnyHeader();
                    pol.AllowAnyMethod();
                    pol.AllowAnyOrigin();
                });
                //cfg.AddPolicy(name: MyAllowSpecificOrigins,
                //  policy =>
                //  {
                //      policy.WithOrigins("http://localhost:5173"); // add the allowed origins
                //  });
            });
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy.WithOrigins("http://localhost:19008",
            //                                              "http://www.contoso.com"); // add the allowed origins  
            //                      });
            //});

            builder.Services.AddSingleton<TokensManager>(new TokensManager()
            {
                Issuer = issuer,
                Audience = audience,
                ExpiresInSeconds = expiresInSeconds,
                Key = key
            });
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(key)),
                    ValidateLifetime = true,
                    ClockSkew = System.TimeSpan.Zero,
                    ValidateIssuerSigningKey = true
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            var port = app.Configuration["Port"];
            if (port != null)
                app.Run($"https://localhost:{port}");
            else
                app.Run();
        }
    }
}