using System.Globalization;
using BlazorMinimalApis.Lib.Session;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.ExceptionFilter;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using DaMi.SO.Manager.Data;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DaMiSoManagerContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:main"]));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<DaMiSoManagerContext>>();
builder.Services.AddScoped(typeof(IServiceCrud<>), typeof(ServiceCrud<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers(option =>
{
    option.Filters.Add<CrudExceptionFilterAttribute>();
}).AddSessionStateTempDataProvider();
builder.Services.AddBlazorBootstrap();
builder.Services.ConfigMapping();
builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(o =>
{
    o.LoginPath = "/Login";
});
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("ViewOrder", policy => policy.RequireAssertion((context) =>
        context.User.HasClaim(c => c.Type == nameof(Permision.ViewLimitOrder))
        || context.User.HasClaim(c => c.Type == nameof(Permision.ViewFullOrder))));

    o.AddPolicy(nameof(Permision.AddNewOrder), policy => policy.RequireClaim(nameof(Permision.AddNewOrder)));
    o.AddPolicy(nameof(Permision.UpdateOrder), policy => policy.RequireClaim(nameof(Permision.UpdateOrder)));
    o.AddPolicy(nameof(Permision.DeleteOrder), policy => policy.RequireClaim(nameof(Permision.DeleteOrder)));
    o.AddPolicy(nameof(Permision.AcceptOrder), policy => policy.RequireClaim(nameof(Permision.AcceptOrder)));
    o.AddPolicy(nameof(Permision.CancelOrder), policy => policy.RequireClaim(nameof(Permision.CancelOrder)));
    o.AddPolicy(nameof(Permision.SuspendOrder), policy => policy.RequireClaim(nameof(Permision.SuspendOrder)));
    o.AddPolicy(nameof(Permision.ChangeStatusOrder), policy => policy.RequireClaim(nameof(Permision.ChangeStatusOrder)));
});
builder.Services.AddLogging(c =>
{

    c.AddDebug();
    c.AddConsole();
});
const string defaultCulture = "vi-VN";
List<CultureInfo> supportedCultures = [new CultureInfo(defaultCulture)];

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddAntiforgery();

builder.Services.AddTransient<SessionManager>();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews(options => options.ValueProviderFactories.Add(new ClaimValueProviderFactory()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAntiforgery();
app.MapControllers();
app.UseRequestLocalization();
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
app.UseCookiePolicy(cookiePolicyOptions);
app.UseAuthentication();

app.UseAuthorization();

app.Run();
