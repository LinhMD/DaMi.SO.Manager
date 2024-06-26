using System.Globalization;
using BlazorMinimalApis.Lib.Session;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.ExceptionFilter;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using DaMi.SO.Manager.Components;
using DaMi.SO.Manager.Data;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.Notifications;
using DaMi.SO.Manager.Hubs;
using DaMi.SO.Manager.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DaMiSoManagerContext>
(
    o => o.UseSqlServer(builder.Configuration["ConnectionStrings:main"], o => o.UseCompatibilityLevel(120)),
    ServiceLifetime.Transient
);

builder.Services.AddTransient<IUnitOfWork, UnitOfWork<DaMiSoManagerContext>>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IServiceCrud<>), typeof(ServiceCrud<>));
builder.Services.AddSignalR();


builder.Services.AddControllers(option =>
{
    option.Filters.Add<CrudExceptionFilterAttribute>();
}).AddSessionStateTempDataProvider();
builder.Services.AddBlazorBootstrap();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressServerSideBlazorReportViewer();

builder.Services.ConfigMapping();
builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(o =>
{
    o.LoginPath = "/Login";
    o.AccessDeniedPath = "/forbidden";
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddAntiforgery();
builder.Services.AddTransient<SessionManager>();
builder.Services.AddHttpContextAccessor();
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<NotificationHub>("/notification");
app.UseRequestLocalization();
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
});
app.UseAuthentication();

app.UseAuthorization();

app.Run();
