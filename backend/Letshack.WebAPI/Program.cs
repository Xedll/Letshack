using System.Text;
using Letshack.Application;
using Letshack.DataAccess;
using Letshack.Domain.Models;
using Letshack.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    // var basePath = AppContext.BaseDirectory;
    // var xmlPath = Path.Combine(basePath, "Letshack.WebAPI.xml");
    // opts.IncludeXmlComments(xmlPath,true);
});
builder.Services.AddControllers();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(configuration =>
    {
        configuration.AllowAnyHeader();
        configuration.AllowAnyOrigin();
        configuration.AllowAnyMethod();
    });
});


builder.Services
    .AddDefaultIdentity<User>(opts =>
    {
        opts.SignIn.RequireConfirmedAccount = false;
        opts.SignIn.RequireConfirmedEmail = false;
        opts.SignIn.RequireConfirmedPhoneNumber = false;
        opts.Password.RequireDigit = false;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireUppercase = false;
        opts.ClaimsIdentity.UserIdClaimType = "UserId";
    })
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] 
                                   ?? throw new Exception("jwt key not found"))),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization();

builder.Services
    .AddApplication()
    .AddDataAccess();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
//                        throw new Exception("connection string not found");

var connectionString = builder.Configuration.GetConnectionString("ConnectionString") ??
                       throw new Exception("connection string not found");

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseCors();

app.UseExceptionHandler(_ => { });

app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
