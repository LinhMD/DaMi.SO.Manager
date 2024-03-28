using BlazorMinimalApis.Lib.Session;
using CrudApiTemplate.Repository;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DaMiSoManagerContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:main"]));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<DaMiSoManagerContext>>();
builder.Services.AddControllers();
builder.Services.ConfigMapping();

builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAntiforgery();

builder.Services.AddTransient<SessionManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".blazorminimalapi.pages";
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});
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

app.UseStaticFiles();
app.UseSession();
app.UseAntiforgery();

app.UseAuthorization();

app.MapControllers();

app.Run();
