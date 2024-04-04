using System.Globalization;
using BlazorMinimalApis.Lib.Session;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using DaMi.SO.Manager.Data;
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

builder.Services.AddControllers().AddSessionStateTempDataProvider();
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
builder.Services.AddAuthorization();
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
