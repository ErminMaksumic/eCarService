using eCarService.Model;
using eCarService.Model.SearchObjects;
using eCarService.Security;
using eCarService.Service;
using eCarService.Service.Implementation;
using eCarService.Service.Interfaces;
using eProdaja.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

//builder.Services.AddTransient<IBaseService<eCarService.Model.CarBrand, object>,
//    BaseService<eCarService.Model.CarBrand, CarBrand, object>>();
builder.Services.AddTransient<ICarBrandService, CarBrandService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPartService, PartService>();
builder.Services.AddTransient<ICarServiceService, CarServiceService>();
builder.Services.AddTransient<IOfferService, OfferService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IAdditionalServiceService, AdditionalServiceService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddScoped<IBaseService<Role, BaseSearchObject>, RoleService>();

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});


builder.Services.AddAutoMapper(typeof(Mapper).Assembly);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eCarService.Database.eCarServiceContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
