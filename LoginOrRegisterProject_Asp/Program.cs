using FluentValidation.AspNetCore;
using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Profilies;
using LoginOrRegisterProject_Asp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddFluentValidation(config =>
//{
//    config.ConfigureClientsideValidation(enabled: false);
//});

builder.Services.AddDbContext<Login_DB_Context>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddSingleton<RegisterService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}






app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginOrRegister}/{action=LoginOrRegisterUser}/{id?}");

app.Run();
