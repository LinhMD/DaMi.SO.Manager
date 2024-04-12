using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Utilities;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.Logins.Pages;
using DaMi.SO.Manager.Endpoints.Share;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DaMi.SO.Manager.Endpoints.Logins;

[ApiController]
[Route("[controller]")]
public class LoginController(IUnitOfWork work) : ControllerBase
{
    [HttpGet]
    public IResult GetLogin()
    {
        return this.Page<Login, LoginRequest>(new LoginRequest());
    }

    [Authorize]
    [HttpGet("Logout")]
    public async Task<IResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Results.Redirect("Login");
    }
    [HttpPost]
    public async Task<IResult> LoginWithPassword([FromForm] LoginRequest request)
    {
        var user = await work.Get<Employee>().IncludeAll()
                        .Include(e => e.Department)
                        .ThenInclude(d => d.Permision)
                        .Where(user => user.EmployeeId == request.EmployeeID).FirstOrDefaultAsync();

        if (user == null)
        {
            return this.Page<Login, LoginRequest>(request, new ValidationResponse()
            {
                Errors = [
                        new ValidationError(){
                        MemberName = nameof(LoginRequest.EmployeeID),
                        Message = "EmployeeID Not found"
                    }
                ]
            });
        }

        var hash = LoginHelper.ComputeHash(Encoding.UTF8.GetBytes(request.Password), Encoding.UTF8.GetBytes(user!.PwSalt ?? ""));
        if (hash != user.PwHash)
        {
            return this.Page<Login, LoginRequest>(request, new ValidationResponse()
            {
                Errors = [
                        new ValidationError(){
                        MemberName = nameof(LoginRequest.Password),
                        Message = "Incorrect Password"
                    }
                ]
            });
        }

        List<Claim> claims = [
            new (ClaimTypes.Name, user.EmployeeName.ToString()),
            new (ClaimTypes.Sid, user.EmployeeId.ToString()),
            new (ClaimTypes.NameIdentifier, user.RowUniqueId.ToString()),
            new (ClaimTypes.Role, user.DepartmentId),
            new (ClaimTypes.Email, user?.Email ?? ""),

        ];
        List<Claim> Permissions = [
            new (nameof(user.Department.Permision.View), user?.Department.Permision.View.ToString() ?? ""),
            new (nameof(user.Department.Permision.AddNew), user?.Department.Permision.AddNew.ToString()?? ""),
            new (nameof(user.Department.Permision.Delete), user?.Department.Permision.Delete.ToString()?? ""),
            new (nameof(user.Department.Permision.Update), user?.Department.Permision.Update.ToString()?? ""),
            new (nameof(user.Department.Permision.ViewLimitOrder), user?.Department.Permision.ViewLimitOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.ViewFullOrder), user?.Department.Permision.ViewFullOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.AddNewOrder), user?.Department.Permision.AddNewOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.DeleteOrder), user?.Department.Permision.DeleteOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.UpdateOrder), user?.Department.Permision.UpdateOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.AcceptOrder), user?.Department.Permision.AcceptOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.CancelOrder), user?.Department.Permision.CancelOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.SuspendOrder), user?.Department.Permision.SuspendOrder.ToString()?? ""),
            new (nameof(user.Department.Permision.ChangeStatusOrder), user?.Department.Permision.ChangeStatusOrder.ToString()?? "")
        ];
        claims.AddRange(Permissions.Where(x => x.Value == "True").ToList());
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal([claimsIdentity]));
        return Results.Redirect("/Index");
    }

    [Authorize]
    [HttpGet("Reset")]
    public async Task<IResult> GetResetPassword()
    {
        string? EmployeeUID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
        Employee? employee = await work.Get<Employee>().GetAsync(new Guid(EmployeeUID));
        if (employee is null)
        {
            return new RazorComponentResult(typeof(_404));
        }
        return this.Page<NewPassword, Employee>(employee);
    }

    [Authorize]
    [HttpPost("Reset")]
    public async Task<IResult> CreatePassword([FromForm] string newPassword, [FromForm] string UserName)
    {
        var user = await work.Get<Employee>().IncludeAll()
                        .Include(e => e.Department)
                        .ThenInclude(d => d.Permision)
                        .Where(user => user.EmployeeId == UserName).FirstOrDefaultAsync();

        if (user is null)
        {
            return new RazorComponentResult(typeof(_404));
        }

        string salt = LoginHelper.GenerateSalt();
        user.PwSalt = salt;
        user.PwHash = LoginHelper.ComputeHash(Encoding.UTF8.GetBytes(newPassword),
            Encoding.UTF8.GetBytes(salt));
        try
        {
            await work.CompleteAsync();
        }
        catch (Exception e)
        {
            e.Dump();
        }
        return Results.Redirect("/Index");
    }

    private static class LoginHelper
    {
        public static string GenerateSalt()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(5));
        }

        public static string ComputeHash(byte[] password, byte[] salt)
        {
#pragma warning disable SYSLIB0041 // Type or member is obsolete
            var byteResult = new Rfc2898DeriveBytes(password, salt, 10000);
#pragma warning restore SYSLIB0041 // Type or member is obsolete
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

    }
}
public class LoginRequest
{
    public string? SignInError { get; set; }
    public string EmployeeID { get; set; } = "";
    public string Password { get; set; } = "";
}