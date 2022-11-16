using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serve.API.Data;
using Serve.Core.Models;
using Serve.Domain.LogicInterfaces;
using Serve.Infrastructure.LogicImplementation;
using Serve.Persistence.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
// For Entity Framework
builder.Services.AddDbContext<ServeDbContext>
    (options => options.UseSqlServer("Server=(localdb)\\MSSQLlocalDB;Database=ServeDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

//(localdb)\MSSQLlocalDB db name


// For Identity
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer("Server=(localdb)\\MSSQLlocalDB;Database=ServeDb;Trusted_Connection=True;MultipleActiveResultSets=true"));




// Add identity service
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
     options.User.AllowedUserNameCharacters = null)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


//Add Auth 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


//builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddControllersWithViews();
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IRepositoryManager, ManagerRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
