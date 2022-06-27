using Microsoft.EntityFrameworkCore;
using UCity.Data.Repositories;
using UCity.Common.Tools;
using WebApi.Middleware;
using UCity.Data.Models.ServiceModels;
using UCity.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

DI.Init(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    AddAdminAccount(app);
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();


void AddAdminAccount(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context!.Accounts.Add(new UCity.Data.Models.Auth.Account
        {
            Name = "Admin",
            Email = "example@mail.ru",
            PasswordHash = "$2a$11$0VQzBodzVUrQUjCWyXqwCOa.Kc2vT09eUwJR9kSqZ9PsICpfYLHOm",
            Role = UCity.Data.Models.Auth.Role.Admin
        });

        context.SaveChanges();
    }
}